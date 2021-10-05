using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.Models
{
    public class ApplicationUser
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("Gender")]
        public string? Gender { get; set; }

        [Column("Date_Of_Birth", TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
    }
}
