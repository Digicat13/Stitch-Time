using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class Status : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Report> Reports { get; set; }

    }
}
