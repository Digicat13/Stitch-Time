

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;

namespace StitchTime.Services
{
    class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InfoByUserDto> GetInfoById(int Id)
        {
            //get user
            var infoByUser=new InfoByUserDto();
            var entity = await _unitOfWork.UserRepository.GetById(Id);
            var user = new UserViewDto();
            _mapper.Map(entity,user);
            infoByUser.User = user;

            //get projects
            var entities = _unitOfWork.ProjectRepository.GetAll().Where()

            return infoByUser;

        }
    }
}
