using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class Project : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProjectManagerId { get; set; }

        public User ProjectManager { get; set; }

        public List<Report> Reports { get; set; }
    }
}
