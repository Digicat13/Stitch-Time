using AutoMapper;
using StitchTime.Core.Dto;
using StitchTime.Core.Entities;

namespace StitchTime.Core
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<PositionDto, Position>().ReverseMap();
            CreateMap<PasswordDto, Password>().ReverseMap();
            CreateMap<ReportDto, Report>().ReverseMap();
            CreateMap<StatusDto, Status>().ReverseMap();
            CreateMap<AssignmentDto, Assignment>().ReverseMap();
            CreateMap<UserViewDto, User>().ReverseMap();
        }
    }
}
