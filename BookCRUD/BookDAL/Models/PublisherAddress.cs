using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookDAL.Models
{
    [Table("Publisher_address")]
    public partial class PublisherAddress
    {
        [Key]
        public int Id { get; set; }
        [Column("Publisher_id")]
        public int PublisherId { get; set; }
        [StringLength(50)]
        public string AddressLine1 { get; set; }
        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [ForeignKey(nameof(PublisherId))]
        [InverseProperty("PublisherAddresses")]
        public virtual Publisher Publisher { get; set; }
    }
}
