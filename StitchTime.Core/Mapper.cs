using System.Collections.Generic;
using System.Linq;
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
            CreateMap<ProjectViewDto, Project>().ReverseMap();
            CreateMap<TeamMemberDto, TeamMember>().ReverseMap();
            CreateMap<TeamDto, Team>().ReverseMap();

            CreateMap<InfoByUserDto, User>().ReverseMap()
                .ForMember(m=>m.User,opt=>opt.MapFrom(x=>x))
                .ForMember(m=>m.Position,opt=>opt.MapFrom(x=>x.Position))
                .ForMember(m=>m.Reports,opt=>opt.MapFrom(x=>x.Reports))
                .ForMember(m=>m.Projects,opt=>opt.MapFrom(x=>x.MemberTeams.Select(t=> t.Team.Project)));

            CreateMap<PmInfoDto, User>().ReverseMap()
                .ForMember(m => m.User, opt => opt.MapFrom(x => x))
                .ForMember(m => m.Developers, 
                    opt => opt.MapFrom(x => x.ManageProjects.SelectMany(p=>p.Reports.SelectMany(r=>r.User.MemberTeams.Select(t=>t.Team)))))
                .ForMember(m => m.Projects, opt => opt.MapFrom(x => x.ManageProjects))
                .ForMember(m => m.TeamMembersReports, 
                    opt => opt.MapFrom(x=>x.ManageProjects.SelectMany(p=>p.Reports.ToList())));

        }
    }
}
