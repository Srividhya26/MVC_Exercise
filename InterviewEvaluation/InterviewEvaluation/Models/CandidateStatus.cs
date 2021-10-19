using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("CandidateStatus")]
    public partial class CandidateStatus
    {
        public CandidateStatus()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Round_Id")]
        public int RoundId { get; set; }
        [Column("Candidate_Id")]
        public int CandidateId { get; set; }
        [Column("Status_Id")]
        public int StatusId { get; set; }
        public int? InterviewerId { get; set; }

        [ForeignKey(nameof(CandidateId))]
        [InverseProperty("CandidateStatuses")]
        public virtual Candidate Candidate { get; set; }
        [ForeignKey(nameof(InterviewerId))]
        [InverseProperty("CandidateStatuses")]
        public virtual Interviewer Interviewer { get; set; }
        [ForeignKey(nameof(RoundId))]
        [InverseProperty("CandidateStatuses")]
        public virtual Round Round { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty("CandidateStatuses")]
        public virtual Status Status { get; set; }
        [InverseProperty(nameof(Review.Candidatestatus))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
