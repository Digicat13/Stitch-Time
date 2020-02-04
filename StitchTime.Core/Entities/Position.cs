using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class Position : IEntity<int>
    {
        public int Id { get; set; }

        public string PositionName { get; set; }

        public List<User> Users { get; set; }

    }
}
