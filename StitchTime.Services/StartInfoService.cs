using AutoMapper;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using System.Collections.Generic;
using System.Linq;

namespace StitchTime.Services
{
    public class StartInfoService : IStartInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StartInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public StartInfoDto GetStartInfo()
        {
            List<StatusDto> StatusList = _unitOfWork.StatusRepository.GetAll().Select(el => _mapper.Map(el, new StatusDto())).ToList();
            List<AssignmentDto> AssignmentList = _unitOfWork.AssignmentRepository.GetAll().Select(el => _mapper.Map(el, new AssignmentDto())).ToList();
            List<PositionDto> PositionList = _unitOfWork.PositionRepository.GetAll().Select(el => _mapper.Map(el, new PositionDto())).ToList();

            var InfoDto = new StartInfoDto
            {
                statusDto = StatusList,
                assignmentDto = AssignmentList,
                positionDto = PositionList
            };

            return InfoDto;
        }
    }
}
