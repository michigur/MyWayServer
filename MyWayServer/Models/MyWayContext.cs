using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyWayServer.Models
{
    public partial class MyWayContext : DbContext
    {
        public MyWayContext()
        {
        }

        public MyWayContext(DbContextOptions<MyWayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarRoutteType> CarRoutteTypes { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Fleet> Fleets { get; set; }
        public virtual DbSet<IsAvailabl> IsAvailabls { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<RoutteCar> RoutteCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=MyWay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CarCurrentLocation).HasMaxLength(200);

                entity.Property(e => e.CarTypeId).HasColumnName("CarTypeID");

                entity.Property(e => e.FleetId).HasColumnName("FleetID");

                entity.HasOne(d => d.CarType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarTypeId)
                    .HasConstraintName("FK_CarTypeID");

                entity.HasOne(d => d.Fleet)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.FleetId)
                    .HasConstraintName("FK_FleetID");
            });

            modelBuilder.Entity<CarRoutteType>(entity =>
            {
                entity.ToTable("CarRoutteType");

                entity.Property(e => e.CarRoutteTypeId).HasColumnName("CarRoutteTypeID");

                entity.Property(e => e.CarRoutteName).HasMaxLength(1);
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("CarType");

                entity.Property(e => e.CarTypeId).HasColumnName("CarTypeID");

                entity.Property(e => e.CarTypeName).HasMaxLength(1);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClientCreditCardCvv).HasColumnName("ClientCreditCardCVV");

                entity.Property(e => e.ClientCreditCardDate).HasColumnType("datetime");

                entity.Property(e => e.ClientCreditCardNumber).HasMaxLength(100);

                entity.Property(e => e.ClientCurrentLocation).HasMaxLength(200);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ClientsBirthDay).HasColumnType("datetime");

                entity.Property(e => e.ClientsEmail)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ClientsGenedr)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ClientsLastName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ClientsPassword)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ClientsUsername)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Fleet>(entity =>
            {
                entity.ToTable("Fleet");

                entity.Property(e => e.FleetId).HasColumnName("FleetID");

                entity.Property(e => e.FleetDrivingLimit).HasMaxLength(200);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Fleets)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_ManagerID");
            });

            modelBuilder.Entity<IsAvailabl>(entity =>
            {
                entity.HasKey(e => e.IsAvailableId)
                    .HasName("PK__IsAvaila__02FF2B0E49B742F6");

                entity.ToTable("IsAvailabl");

                entity.Property(e => e.IsAvailableId).HasColumnName("IsAvailableID");

                entity.Property(e => e.IsAvailableName)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerBirthDay).HasColumnType("datetime");

                entity.Property(e => e.ManagerEmail)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ManagerGenedr)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ManagerLastName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ManagerPassword)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ManagerType).HasMaxLength(30);

                entity.Property(e => e.ManagerUsername)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RoutteCar>(entity =>
            {
                entity.HasKey(e => e.RouteCarId)
                    .HasName("PK__RoutteCa__218787560AD8D88D");

                entity.ToTable("RoutteCar");

                entity.Property(e => e.RouteCarId).HasColumnName("RouteCarID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CarRoutteTypeId).HasColumnName("CarRoutteTypeID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.RouteArrivalLocation).HasMaxLength(200);

                entity.Property(e => e.RouteArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.RouteDeputureLocation).HasMaxLength(200);

                entity.Property(e => e.RouteDeputureTime).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.RoutteCars)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_CarID");

                entity.HasOne(d => d.CarRoutteType)
                    .WithMany(p => p.RoutteCars)
                    .HasForeignKey(d => d.CarRoutteTypeId)
                    .HasConstraintName("FK_CarRoutteTypeID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RoutteCars)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_clientID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
