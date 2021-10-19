using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    public partial class Round
    {
        public Round()
        {
            CandidateStatuses = new HashSet<CandidateStatus>();
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        [Column("R_Id")]
        public int RId { get; set; }
        [Column("Round_Name")]
        [StringLength(25)]
        public string RoundName { get; set; }

        [InverseProperty(nameof(CandidateStatus.Round))]
        public virtual ICollection<CandidateStatus> CandidateStatuses { get; set; }
        [InverseProperty(nameof(SkillRating.Round))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
