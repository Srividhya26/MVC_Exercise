using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookDAL.Models
{
    [Table("BookCategory")]
    public partial class BookCategory
    {
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("BC_Id")]
        public int BcId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedAt { get; set; }

        [InverseProperty(nameof(Book.Category))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
