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

        public async Task<InfoByUserDto> GetInfoById(string Id)
        {
            var infoByUser = new InfoByUserDto();

            var entity = _unitOfWork.UserRepository
                .GetAll().Where(x => x.Id == Id) // == .GetById(Id)
                .Include(x => x.Position)
                .Include(x => x.MemberTeams)
                .ThenInclude(x => x.Team)
                .ThenInclude(x=>x.Project)
                .Include(x => x.Reports)
                .ToList()
                .FirstOrDefault();

            await _unitOfWork.SaveAsync();
            _mapper.Map(entity, infoByUser);
            return infoByUser;
        }
    }
}
