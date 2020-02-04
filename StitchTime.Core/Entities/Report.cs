using System;

namespace StitchTime.Core.Entities
{
    public class Report : IEntity<int>
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        public string Description { get; set; }

        public double Time { get; set; }

        public double Overtime { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
