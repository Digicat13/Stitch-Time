﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using StitchTime.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StitchTime.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ProjectDto> GetAll()
        {
            return _unitOfWork.ProjectRepository.GetAll().Include(x=>x.Team).Select(el => _mapper.Map(el, new ProjectDto())).ToList();
        }

        public ProjectDto GetById(int Id)
        {
            var entity = _unitOfWork.ProjectRepository.GetAll().Where(x=>x.Id==Id).Include(x=>x.Team).ThenInclude(x=>x.TeamMembers).ToList().FirstOrDefault();
            var dto = new ProjectDto();
            _mapper.Map(entity, dto);
            return dto;
        }

        public async Task<ProjectDto> Insert(ProjectDto ProjectDto)
        {
            var entity = new Project();
            _mapper.Map(ProjectDto, entity);
            await _unitOfWork.ProjectRepository.Insert(entity);
            var user = _unitOfWork.UserRepository.GetById(ProjectDto.Team.TeamLeadId).Result;
            user.PositionId = 2;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
            _mapper.Map(entity, ProjectDto);
            return ProjectDto;
        }

        public ProjectDto Update(ProjectDto ProjectDto)
        {
            var entity = new Project();
            _mapper.Map(ProjectDto, entity);
            _unitOfWork.ProjectRepository.Update(entity);
            _unitOfWork.Save();
            _mapper.Map(entity, ProjectDto);
            return ProjectDto;
        }

        public async Task Delete(int Id)
        {
            await _unitOfWork.ProjectRepository.Delete(Id);
            await _unitOfWork.SaveAsync();
        }
    }
}