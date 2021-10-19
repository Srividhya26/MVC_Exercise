using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("Rating")]
    public partial class Rating
    {
        public Rating()
        {
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        [Column("Rating_Id")]
        public int RatingId { get; set; }
        [Column("Rating_Name")]
        [StringLength(25)]
        public string RatingName { get; set; }

        [InverseProperty(nameof(SkillRating.Rating))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
