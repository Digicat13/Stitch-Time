using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class Assignment : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Report> Reports { get; set; }

    }
}