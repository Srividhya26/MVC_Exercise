using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("Interviewer")]
    public partial class Interviewer
    {
        public Interviewer()
        {
            CandidateStatuses = new HashSet<CandidateStatus>();
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        [Column("I_Id")]
        public int IId { get; set; }
        [Column("Interviewer_Name")]
        [StringLength(25)]
        public string InterviewerName { get; set; }
        [Column("Interviewer_sign")]
        [StringLength(25)]
        public string InterviewerSign { get; set; }

        [InverseProperty(nameof(CandidateStatus.Interviewer))]
        public virtual ICollection<CandidateStatus> CandidateStatuses { get; set; }
        [InverseProperty(nameof(SkillRating.Interviewer))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
