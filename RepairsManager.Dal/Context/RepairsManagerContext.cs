using Microsoft.EntityFrameworkCore;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context
{
    public partial class RepairsManagerContext : DbContext
    {
        public RepairsManagerContext(DbContextOptions<RepairsManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialParty> MaterialParty { get; set; }
        public virtual DbSet<MaterialUnits> MaterialUnits { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<RepairPart> RepairPart { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleMark> VehicleMark { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();;

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

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
                    .HasName("UQ__Material__78A1A19D6E48A9E8")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Number).HasMaxLength(16);

                entity.Property(e => e.Receipt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MaterialUnits>(entity =>
            {
                entity.ToTable("Material_units");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Material__737584F6720D0D0C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RepairDate).HasColumnType("datetime");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Repair)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Repair_fk0");
            });

            modelBuilder.Entity<RepairPart>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Repair_part");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Work)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('Заменено')");

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
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(e => e.RegNumber)
                    .HasName("UQ__Vehicle__18B201F699F7FD79")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RegNumber)
                    .IsRequired()
                    .HasColumnName("Reg_number")
                    .HasMaxLength(16);

                entity.HasOne(d => d.VehicleModel)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_fk0");
            });

            modelBuilder.Entity<VehicleMark>(entity =>
            {
                entity.ToTable("Vehicle_mark");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Vehicle___737584F68AA5465E")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.ToTable("Vehicle_model");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Vehicle___737584F61CFC43C3")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.VehicleMark)
                    .WithMany(p => p.VehicleModel)
                    .HasForeignKey(d => d.VehicleMarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_model_fk0");
            });
        }
    }
}
