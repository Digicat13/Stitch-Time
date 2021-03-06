﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StitchTime.Core.Entities;

namespace StitchTime.DAL
{
    public class StitchTimeApiContext : IdentityDbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<TeamMember> TeamMember { get; set; }

        public StitchTimeApiContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(e => e.Position)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.PositionId)
                .HasConstraintName("User_Position");

                entity.HasMany(e => e.LeadTeams)
                .WithOne(e => e.TeamLead)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.TeamLeadId)
                .HasConstraintName("Team_TeamLead");

                entity.HasMany(e => e.ManageProjects)
                .WithOne(e => e.ProjectManager)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ProjectManagerId)
                .HasConstraintName("Project_ProjectManager");

                entity.HasMany(e => e.MemberTeams)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("TeamMember_User");

                entity.HasMany(e => e.Reports)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("Report_User");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasMany(e => e.TeamMembers)
                .WithOne(e => e.Team)
                .HasForeignKey(e => e.TeamId)
                .HasConstraintName("TeamMember_Team");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasOne(e => e.Project)
                .WithMany(e => e.Reports)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ProjectId)
                .HasConstraintName("Report_Project");

                entity.HasOne(e => e.Assignment)
                .WithMany(e => e.Reports)
                .HasForeignKey(e => e.AssignmentId)
                .HasConstraintName("Report_Assignment");

                entity.HasOne(e => e.Status)
                .WithMany(e => e.Reports)
                .HasForeignKey(e => e.StatusId)
                .HasConstraintName("Report_Status");
            });

            modelBuilder.Entity<Assignment>().HasData(
                new Assignment() { Id = 1, Name = "Developing"},
                new Assignment() { Id = 2, Name = "For review"},
                new Assignment() { Id = 3, Name = "In review"}, 
                new Assignment() { Id = 4, Name = "Bug fixing" }
                );

            modelBuilder.Entity<Status>().HasData(
                new Status() { Id = 1, Name = "Opened"},
                new Status() { Id = 2, Name = "Notified"},
                new Status() { Id = 3, Name = "Accepted"},
                new Status() { Id = 4, Name = "Declined"}
                );

            modelBuilder.Entity<Position>().HasData(
                new Position() { Id = 1, PositionName = "Developer"},
                new Position() { Id = 2, PositionName = "TeamLead"},
                new Position() { Id = 3, PositionName = "ProjectManager" }
                );
        }
    }
}
