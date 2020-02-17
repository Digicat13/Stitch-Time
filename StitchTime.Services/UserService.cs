using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;

namespace StitchTime.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public InfoByUserDto GetInfoById(string Id)
        {
            var infoByUser = new InfoByUserDto();

            var entity = _unitOfWork.UserRepository
                .GetAll().Where(x => x.Id == Id)
                .Include(x => x.Position)
                .Include(x => x.MemberTeams)
                .ThenInclude(x => x.Team)
                .ThenInclude(x=>x.Project)
                .Include(x => x.Reports)
                .ToList()
                .FirstOrDefault();

            _mapper.Map(entity, infoByUser);
            return infoByUser;
        }

        public PmProjectsInfoDto GetPmProjectsInfo(string Id)
        {
            var pmProjectsInfo = new PmProjectsInfoDto();
            var entity = _unitOfWork.UserRepository
                .GetAll().Where(x => x.Id == Id)
                .Include(x=>x.ManageProjects)
                .ToList()
                .FirstOrDefault();
            
            var users = new List<UserViewDto>();
            _mapper.Map(_unitOfWork.UserRepository.GetAll().ToList(), users);
            _mapper.Map(entity, pmProjectsInfo);
            pmProjectsInfo.Users = users;

            return pmProjectsInfo;
        }

        public PmReportsInfoDto GetPmReportsInfo(string Id)
        {
            var pmReportsInfo = new PmReportsInfoDto();

            var entity = _unitOfWork.UserRepository
                .GetAll()
                .Where(x => x.Id == Id)
                .Include(x => x.ManageProjects)
                .ThenInclude(x => x.Reports);

            var users = new List<UserViewDto>();
            _mapper.Map(_unitOfWork.UserRepository
                .GetAll()
                .Where(x => x.MemberTeams.Select(t => t.Team.Project.ProjectManager.Id).First() == Id).ToList(), users);
            _mapper.Map(entity,pmReportsInfo);
            pmReportsInfo.PmDevelopers = users;

            return pmReportsInfo;
        }
    }
}
