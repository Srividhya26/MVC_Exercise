using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("Candidate")]
    public partial class Candidate
    {
        public Candidate()
        {
            CandidateStatuses = new HashSet<CandidateStatus>();
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        //[Column("C_Id")]
        public int CId { get; set; }
        //[Column("Referral_Name")]
        [StringLength(25)]
        public string ReferralName { get; set; }
        //[Column("Candidate_Name")]
        [StringLength(25)]
        public string CandidateName { get; set; }
        //[Column("Last_Employer")]
        [StringLength(25)]
        public string LastEmployer { get; set; }
        //[Column("Last_Designation")]
        [StringLength(25)]
        public string LastDesignation { get; set; }
        //[Column("Total_Experience")]
        public int? TotalExperience { get; set; }
        [StringLength(25)]
        public string Sources { get; set; }
        //[Column("Health_condition")]
        [StringLength(25)]
        public string HealthCondition { get; set; }
        public bool? IsDeleted { get; set; }
        //[Column("Notice_Period", TypeName = "decimal(18, 0)")]
        public decimal? NoticePeriod { get; set; }
        [StringLength(250)]
        public string Resume { get; set; }

        [InverseProperty(nameof(CandidateStatus.Candidate))]
        public virtual ICollection<CandidateStatus> CandidateStatuses { get; set; }
        [InverseProperty(nameof(SkillRating.Candidate))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
