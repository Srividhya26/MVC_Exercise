using BusinessObjectLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.Data
{
    public partial class TimeEntryAppContext : DbContext
    {
        public TimeEntryAppContext()
        {
        }

        public TimeEntryAppContext(DbContextOptions<TimeEntryAppContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Break> Breaks { get; set; }
        public virtual DbSet<TimeEntry> Entries { get; set; }
        public virtual DbSet<ApplicationUser> user { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server = TRAINEE-04;Database = TimeEntryApp;User id = SA;Password = Srividhya@2000");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<AspNetUser>(entity =>
//            {
//                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
//                    .IsUnique()
//                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
//            });

//            modelBuilder.Entity<Break>(entity =>
//            {
//                entity.HasOne(d => d.Entry)
//                    .WithMany(p => p.Breaks)
//                    .HasForeignKey(d => d.TimeEntryId)
//                    .HasConstraintName("FK__Break__EntryID__4D94879B");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
