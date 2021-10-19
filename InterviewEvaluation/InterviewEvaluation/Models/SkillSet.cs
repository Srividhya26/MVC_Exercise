using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluation.Models
{
    [Table("SkillSet")]
    public partial class SkillSet
    {
        public SkillSet()
        {
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        [Column("Skillset_Id")]
        public int SkillsetId { get; set; }
        [Column("Skill_Id")]
        public int SkillId { get; set; }
        [Column("SubSkill_Name")]
        [StringLength(25)]
        public string SubSkillName { get; set; }

        [ForeignKey(nameof(SkillId))]
        [InverseProperty("SkillSets")]
        public virtual Skill Skill { get; set; }
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
