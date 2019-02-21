using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RepairsManager.Dal.Models
{
    public partial class RepairsManagerContext : DbContext
    {
        public RepairsManagerContext()
        {
        }

        public RepairsManagerContext(DbContextOptions<RepairsManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialParty> MaterialParty { get; set; }
        public virtual DbSet<MaterialUnits> MaterialUnits { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<RepairPart> RepairPart { get; set; }
        public virtual DbSet<RepairWork> RepairWork { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleMark> VehicleMark { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=RepairsManager;UID=sa;Password=P@ssword1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Material_fk0");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Material_fk1");
            });

            modelBuilder.Entity<MaterialParty>(entity =>
            {
                entity.ToTable("Material_party");

                entity.HasIndex(e => e.Number)
                    .HasName("UQ__Material__78A1A19D7ACEE5F6")
                    .IsUnique();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Receipt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MaterialUnits>(entity =>
            {
                entity.ToTable("Material_units");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Material__737584F630CE3282")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(e => e.RepairDate).HasColumnType("datetime");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Repair)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Repair_fk0");
            });

            modelBuilder.Entity<RepairPart>(entity =>
            {
                entity.ToTable("Repair_part");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.RepairPart)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Repair_part_fk1");

                entity.HasOne(d => d.Repair)
                    .WithMany(p => p.RepairPart)
                    .HasForeignKey(d => d.RepairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Repair_part_fk0");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.RepairPart)
                    .HasForeignKey(d => d.WorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Repair_part_fk2");
            });

            modelBuilder.Entity<RepairWork>(entity =>
            {
                entity.ToTable("Repair_work");

                entity.Property(e => e.WorkName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(e => e.RegNumber)
                    .HasName("UQ__Vehicle__18B201F6FDB19361")
                    .IsUnique();

                entity.Property(e => e.RegNumber)
                    .IsRequired()
                    .HasColumnName("Reg_number")
                    .HasMaxLength(16);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_fk0");
            });

            modelBuilder.Entity<VehicleMark>(entity =>
            {
                entity.ToTable("Vehicle_mark");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Vehicle___737584F66C2B9DBB")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.ToTable("Vehicle_model");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Vehicle___737584F6724F0BAB")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.VehicleModel)
                    .HasForeignKey(d => d.MarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_model_fk0");
            });
        }
    }
}
