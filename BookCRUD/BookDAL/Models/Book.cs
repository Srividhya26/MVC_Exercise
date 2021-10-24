using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookDAL.Models
{
    [Table("Book")]
    public partial class Book
    {
        [Key]
        [Column("Book_Id")]
        public int BookId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [Column("Author_Id")]
        public int AuthorId { get; set; }
        [Column("Publisher_Id")]
        public int PublisherId { get; set; }
        [Column("Category_id")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("Books")]
        public virtual Author Author { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(BookCategory.Books))]
        public virtual BookCategory Category { get; set; }
        [ForeignKey(nameof(PublisherId))]
        [InverseProperty("Books")]
        public virtual Publisher Publisher { get; set; }
    }
}
