using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("Review")]
    public partial class Review
    {
        [Key]
        [Column("Review_Id")]
        public int ReviewId { get; set; }
        [Column("Candidatestatus_Id")]
        public int CandidatestatusId { get; set; }
        [Column("Interview_Date", TypeName = "date")]
        public DateTime? InterviewDate { get; set; }
        [StringLength(50)]
        public string Pros { get; set; }
        [StringLength(50)]
        public string Cons { get; set; }
        [Column("Interviewer_comments")]
        [StringLength(30)]
        public string InterviewerComments { get; set; }
        [StringLength(150)]
        public string Document { get; set; }

        [ForeignKey(nameof(CandidatestatusId))]
        [InverseProperty(nameof(CandidateStatus.Reviews))]
        public virtual CandidateStatus Candidatestatus { get; set; }
    }
}
