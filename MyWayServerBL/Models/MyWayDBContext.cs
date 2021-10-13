using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyWayServerBL.Models
{
    public partial class MyWayDBContext : DbContext
    {
        public MyWayDBContext()
        {
        }

        public MyWayDBContext(DbContextOptions<MyWayDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=MyWayD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.ClientsEmail, "UC_Email")
                    .IsUnique();

                entity.Property(e => e.ClientId).HasColumnName("ID");

                entity.Property(e => e.ClientsEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ClientsLastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ClientsPassword)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
