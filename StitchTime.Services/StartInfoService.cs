using AutoMapper;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
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
            var StatusList = _unitOfWork.StatusRepository.GetAll().Select(el => _mapper.Map(el, new StatusDto())).ToList();
            var AssignmentList = _unitOfWork.AssignmentRepository.GetAll().Select(el => _mapper.Map(el, new AssignmentDto())).ToList();

            var InfoDto = new StartInfoDto
            {
                statusDto = StatusList,
                assignmentDto = AssignmentList
            };

            return InfoDto;
        }
    }
}
