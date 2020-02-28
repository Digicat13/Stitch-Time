using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StitchTime.DAL.Repositories
{
    public class PositonRepository : BaseRepository<Position, int>, IPositionRepository
    {
        public PositonRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
