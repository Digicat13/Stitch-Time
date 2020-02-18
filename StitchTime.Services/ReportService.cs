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

         //   var To = _unitOfWork.UserRepository.GetAll().Where(x => x.Id == (_unitOfWork.ProjectRepository.GetAll().Where(x => x.Id == reportDto.ProjectId).ToList().FirstOrDefault().ProjectManagerId)).ToList().FirstOrDefault().Email;
            var PmId = _unitOfWork.ProjectRepository.GetAll().Where(x => x.Id == reportDto.ProjectId).ToList().FirstOrDefault().ProjectManagerId;
            var EmailTo = _unitOfWork.UserRepository.GetAll().Where(x => x.Id == PmId).ToList().FirstOrDefault().Email;
            SendEmail(new MailboxAddress("User",EmailTo), "You have new report to be checked", "Notified report");

            var TmId = _unitOfWork.TeamRepository.GetAll().Where(x => x.ProjectId == reportDto.ProjectId).ToList().FirstOrDefault().TeamLeadId;
            EmailTo = _unitOfWork.UserRepository.GetAll().Where(x => x.Id == TmId).ToList().FirstOrDefault().Email;
            SendEmail(new MailboxAddress("User", EmailTo), "You have new report to be checked", "Notified report");

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

            TrackStatus(reportDto);
            return reportDto;
        }

        public void TrackStatus(ReportDto reportDto)
        {
           

            if (_unitOfWork.StatusRepository.GetById(reportDto.StatusId).Result.Name == "Accepted")
            {
                _unitOfWork.ProjectRepository.GetById(reportDto.ProjectId).Result.SpentEffort += (reportDto.Time + reportDto.Overtime);
                _unitOfWork.ProjectRepository.GetById(reportDto.ProjectId).Result.InitialRisk += ((reportDto.Time + reportDto.Overtime) / reportDto.Time);
            }
            _unitOfWork.Save();
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
            "stitch.time.admin@ukr.net");

            message.From.Add(From);

            message.To.Add(To);

            message.Subject = Subject;

            BodyBuilder bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = "<p>" + Body + "</p><br> http://localhost:4200/home/notifiedreports";

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.ukr.net", 465, true);

            //client.Authenticate("David.Pozhar.Pz.2017@lpnu.ua", "08.07.1999");

            client.Authenticate("stitch.time.admin@ukr.net", "stitch123");

            client.Send(message);

            client.Disconnect(true);

            client.Dispose();
        }

    }
}
