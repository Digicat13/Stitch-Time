using System;
using System.Collections.Generic;
using System.Text;
using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;

namespace StitchTime.DAL.Repositories
{
    public class TeamMemberRepository : BaseRepository<TeamMember, int>, ITeamMemberRepository
    {
        public TeamMemberRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
