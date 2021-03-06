﻿using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class Project : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbrevation { get; set; }

        public string Description { get; set; }

        public double InitialEffrort { get; set; }

        public double SpentEffort { get; set; }
            
        public double InitialRisk { get; set; }

        public string ProjectManagerId { get; set; }

        public User ProjectManager { get; set; }

        public List<User> UserData { get; set; }

        public List<Report> Reports { get; set; }

        public Team Team { get; set; }
    }
}
