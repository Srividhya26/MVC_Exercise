using InterviewEvaluation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewEvaluation.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateStatus> CandidateStatuses { get; set; }
        public virtual DbSet<Interviewer> Interviewers { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillRating> SkillRatings { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
    }
}
