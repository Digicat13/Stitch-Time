using AutoMapper;
using FluentValidation;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using StitchTime.Core.Entities;
using StitchTime.Core.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

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
            var validator = new ReportValidator();
            validator.ValidateAndThrow(reportDto);
            var entity = new Report();
            _mapper.Map(reportDto, entity);
            entity.CreateDate = System.DateTime.UtcNow;
            entity.UpdateDate = System.DateTime.UtcNow;
            entity.StatusId = 1;
            await _unitOfWork.ReportRepository.Insert(entity);
            await _unitOfWork.SaveAsync();
            _mapper.Map(entity, reportDto);
            return reportDto;
        }

        public ReportDto Update(ReportDto reportDto)
        {
            var entity = new Report();
            _mapper.Map(reportDto, entity);
            entity.StatusId = 1;
            entity.UpdateDate = System.DateTime.UtcNow;
            _unitOfWork.ReportRepository.Update(entity);
            _unitOfWork.Save();
            _mapper.Map(entity, reportDto);
            return reportDto;
        }

        public async Task Delete(int Id)
        {
            await _unitOfWork.ReportRepository.Delete(Id);
            await _unitOfWork.SaveAsync();
        }

        public ReportDto Notify(ReportDto reportDto)
        {
            reportDto.StatusId = 2;
            var entity = new Report();
            _mapper.Map(reportDto, entity);
            entity.UpdateDate = System.DateTime.UtcNow;
            _unitOfWork.ReportRepository.Update(entity);
            _unitOfWork.Save();
            _mapper.Map(entity, reportDto);

            SendEmail(new MailboxAddress("User", _unitOfWork.UserRepository.GetAll().Where(x => x.Id == reportDto.UserId).ToList().FirstOrDefault().Email), "You have new report to be checked", "Notified report");
            return reportDto;

        }

        public ReportDto AcceptReport(ReportDto reportDto)
        {
            reportDto.StatusId = 3;
            var entity = new Report();
            _mapper.Map(reportDto, entity);
            entity.UpdateDate = System.DateTime.UtcNow;
            _unitOfWork.ReportRepository.Update(entity);
            _unitOfWork.Save();
            _mapper.Map(entity, reportDto);
            return reportDto;
        }

        public ReportDto DeclineReport(ReportDto reportDto)
        {
            reportDto.StatusId = 4;
            var entity = new Report();
            _mapper.Map(reportDto, entity);
            entity.UpdateDate = System.DateTime.UtcNow;
            _unitOfWork.ReportRepository.Update(entity);
            _unitOfWork.Save();
            _mapper.Map(entity, reportDto);
            return reportDto;
        }

        public void SendEmail(MailboxAddress To, string Body, string Subject)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress From = new MailboxAddress("Admin",
            "David.Pozhar.Pz.2017@lpnu.ua");

            message.From.Add(From);

            message.To.Add(To);

            message.Subject = Subject;

            BodyBuilder bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = "<h1>ALLERT</h1>";

            bodyBuilder.TextBody = Body;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.mai.com", 463, true);

            //client.Authenticate("David.Pozhar.Pz.2017@lpnu.ua", "08.07.1999");

            client.Authenticate("David.Pozhar.Pz.2017@lpnu.ua", "08.07.1999");

            client.Send(message);

            client.Disconnect(true);

            client.Dispose();
        }
    }
}
