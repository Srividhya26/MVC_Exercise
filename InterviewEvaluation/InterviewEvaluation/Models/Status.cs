using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("Status")]
    public partial class Status
    {
        public Status()
        {
            CandidateStatuses = new HashSet<CandidateStatus>();
        }

        [Key]
        [Column("Status_Id")]
        public int StatusId { get; set; }
        [Column("Status_Name")]
        [StringLength(25)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(CandidateStatus.Status))]
        public virtual ICollection<CandidateStatus> CandidateStatuses { get; set; }
    }
}
