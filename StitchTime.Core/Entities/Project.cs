using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class Project : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

<<<<<<< Updated upstream
        public int ProjectManagerId { get; set; }
=======
        public string Abbrevation { get; set; }

        public string Description { get; set; }

        public double InitialEffrort { get; set; }

        public double SpentEffort { get; set; }

        public double InitialRisk { get; set; }

        public string ProjectManagerId { get; set; }
>>>>>>> Stashed changes

        public User ProjectManager { get; set; }

        public List<Report> Reports { get; set; }
    }
}
