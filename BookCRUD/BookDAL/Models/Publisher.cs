using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookDAL.Models
{
    [Table("Publisher")]
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
            PublisherAddresses = new HashSet<PublisherAddress>();
        }

        [Key]
        [Column("Publisher_Id")]
        public int PublisherId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedAt { get; set; }

        [InverseProperty(nameof(Book.Publisher))]
        public virtual ICollection<Book> Books { get; set; }
        [InverseProperty(nameof(PublisherAddress.Publisher))]
        public virtual ICollection<PublisherAddress> PublisherAddresses { get; set; }
    }
}
