using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;

namespace StitchTime.DAL.Repositories
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        public UserRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
