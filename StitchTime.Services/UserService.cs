using System.Collections.Generic;
using System.Linq;
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
            _mapper.Map(_unitOfWork.UserRepository.GetAll().Where(x=>x.PositionId!=3).ToList(), users);
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
                .ThenInclude(x => x.Reports).ToList().FirstOrDefault();

            var reports = entity.ManageProjects.SelectMany(x => x.Reports
                .Select(r=> _mapper.Map(r, new ReportDto()))).ToList();
            reports = reports.Where(x => (x.StatusId == 2 || x.StatusId == 3)).ToList();
            
            var users = new List<UserViewDto>(); 

            _mapper.Map(_unitOfWork.UserRepository
                .GetAll()
                .Where(x => x.MemberTeams.Select(t => t.Team.Project.ProjectManager.Id).First() == Id).ToList(), users);
           
            _mapper.Map(entity,pmReportsInfo);
            
            pmReportsInfo.PmDevelopers = users;
            pmReportsInfo.DevelopersReports = reports;

            return pmReportsInfo;
        }

        public TeamLeadInfoDto GetTeamLeadInfo(string id)
        {
            var info = new TeamLeadInfoDto();

            var entity = _unitOfWork.UserRepository
                .GetAll()
                .Where(x => x.Id == id)
                .Include(x => x.Reports)
                .Include(x => x.LeadTeams)
                .ThenInclude(x => x.Project)
                .Include(x => x.LeadTeams)
                .ThenInclude(x => x.TeamMembers)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Reports)
                .ToList()
                .FirstOrDefault();

            

            info.UsersReports = entity.LeadTeams.SelectMany(x => x.TeamMembers.SelectMany(t => t.User.Reports.Select(r=>_mapper.Map(r,new ReportDto())))).ToList();
            info.UsersReports = info.UsersReports.Where(x => (x.UserId != entity.Id) && (x.StatusId == 2 || x.StatusId == 3)).ToList();
            info.Users = entity.LeadTeams.SelectMany(x => x.TeamMembers.Select(u=> _mapper.Map(u.User,new UserViewDto())).Where(t=>t.Id != id)).ToList();
            info.Projects = entity.LeadTeams.Select(x => x.Project).Select(p => _mapper.Map(p, new ProjectViewDto())).ToList();
            return info;
        }
    }
}
