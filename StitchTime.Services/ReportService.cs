using AutoMapper;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using StitchTime.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StitchTime.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ReportDto> GetAll()
        {
            return _unitOfWork.ReportRepository.GetAll().Select(el => _mapper.Map(el, new ReportDto())).ToList();
        }

        public async Task<ReportDto> GetById(int Id)
        {
            var entity = await _unitOfWork.ReportRepository.GetById(Id);
            var dto = new ReportDto();
            _mapper.Map(entity, dto);
            return dto;
        }

        public async Task<ReportDto> Insert(ReportDto reportDto)
        {
            var entity = new Report();
            _mapper.Map(reportDto, entity);
            await _unitOfWork.ReportRepository.Insert(entity);
            _unitOfWork.Save();
            _mapper.Map(entity, reportDto);
            return reportDto;
        }

        public ReportDto Update(ReportDto reportDto)
        {
            var entity = new Report();
            _mapper.Map(reportDto, entity);
            _unitOfWork.ReportRepository.Update(entity);
            _unitOfWork.Save();
            _mapper.Map(entity, reportDto);
            return reportDto;
        }

        public async Task Delete(int Id)
        {
           await _unitOfWork.ReportRepository.Delete(Id);
            _unitOfWork.Save();
        }
    }
}
