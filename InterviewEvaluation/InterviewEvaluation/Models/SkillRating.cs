using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("skill_Rating")]
    public partial class SkillRating
    {
        [Key]
        [Column("skill_RatingId")]
        public int SkillRatingId { get; set; }
        [Column("Candidate_id")]
        public int CandidateId { get; set; }
        [Column("Skill_Id")]
        public int SkillId { get; set; }
        [Column("Interviewer_id")]
        public int InterviewerId { get; set; }
        [Column("Rating_Id")]
        public int RatingId { get; set; }
        [Column("Round_id")]
        public int RoundId { get; set; }

        [ForeignKey(nameof(CandidateId))]
        [InverseProperty("SkillRatings")]
        public virtual Candidate Candidate { get; set; }
        [ForeignKey(nameof(InterviewerId))]
        [InverseProperty("SkillRatings")]
        public virtual Interviewer Interviewer { get; set; }
        [ForeignKey(nameof(RatingId))]
        [InverseProperty("SkillRatings")]
        public virtual Rating Rating { get; set; }
        [ForeignKey(nameof(RoundId))]
        [InverseProperty("SkillRatings")]
        public virtual Round Round { get; set; }
        [ForeignKey(nameof(SkillId))]
        [InverseProperty("SkillRatings")]
        public virtual Skill Skill { get; set; }
    }
}
