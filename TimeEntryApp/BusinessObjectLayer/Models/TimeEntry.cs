﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace BusinessObjectLayer.Models
{
    [Table("Entry")]
    public class TimeEntry
    {      
            public TimeEntry()
            {
                Breaks = new HashSet<Break>();
            }

            [Key]
            [Column("ID")]
            public int Id { get; set; }

            [Column(TypeName = "date")]
            [DataType(DataType.Date)]
           
            public DateTime Date { get; set; }
            [Column(TypeName = "datetime")]

            [DataType(DataType.Time)]
         
            public DateTime InTime { get; set; }
            [Column(TypeName = "datetime")]

            [DataType(DataType.Time)]
          
            public DateTime OutTime { get; set; }

            [InverseProperty(nameof(Break.Entry))]
            public virtual ICollection<Break> Breaks { get; set; }

          
        }
    }

