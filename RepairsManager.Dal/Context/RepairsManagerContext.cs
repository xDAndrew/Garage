using Microsoft.EntityFrameworkCore;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context
{
    public class RepairsManagerContext : DbContext
    {
        public RepairsManagerContext()
        {
        }

        public RepairsManagerContext(DbContextOptions<RepairsManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Commission> Commission { get; set; }
        public virtual DbSet<CommissionResponsible> CommissionResponsible { get; set; }
        public virtual DbSet<Defecation> Defecation { get; set; }
        public virtual DbSet<DefecationPart> DefecationPart { get; set; }
        public virtual DbSet<DefecationResponsible> DefecationResponsible { get; set; }
        public virtual DbSet<Depreciation> Depreciation { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePosition { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialParty> MaterialParty { get; set; }
        public virtual DbSet<MaterialUnits> MaterialUnits { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderFault> OrderFault { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleMark> VehicleMark { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=RepairsManager;User Id=sa;Password=P@ssword1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<CommissionResponsible>(entity =>
            {
                entity.ToTable("Commission_responsible");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Commission)
                    .WithMany(p => p.CommissionResponsible)
                    .HasForeignKey(d => d.CommissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Commission_responsible_fk0");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CommissionResponsible)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Commission_responsible_fk1");
            });

            modelBuilder.Entity<Defecation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.HasOne(d => d.Approved)
                    .WithMany(p => p.Defecation)
                    .HasForeignKey(d => d.ApprovedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Defecation_fk2");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.Defecation)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Defecation_fk1");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Defecation)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Defecation_fk0");
            });

            modelBuilder.Entity<DefecationPart>(entity =>
            {
                entity.ToTable("Defecation_part");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("('????????')");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.DefecationPart)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Defecation_part_fk0");
            });

            modelBuilder.Entity<DefecationResponsible>(entity =>
            {
                entity.ToTable("Defecation_responsible");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DefecationId).HasColumnName("defecationId");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.HasOne(d => d.Defecation)
                    .WithMany(p => p.DefecationResponsible)
                    .HasForeignKey(d => d.DefecationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Defecation_responsible_fk0");
            });

            modelBuilder.Entity<Depreciation>(entity =>
            {
                entity.HasIndex(e => e.Number)
                    .HasName("UQ__Deprecia__78A1A19D22E79269")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Organization)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('?? \"????????? ????????? ??????\"')");

                entity.HasOne(d => d.Commission)
                    .WithMany(p => p.Depreciation)
                    .HasForeignKey(d => d.CommissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Depreciation_fk2");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Depreciation)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Depreciation_fk0");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Depreciation)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Depreciation_fk3");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_fk1");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_fk0");
            });

            modelBuilder.Entity<EmployeeDepartment>(entity =>
            {
                entity.ToTable("Employee_department");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Employee__737584F6093C4264")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<EmployeePosition>(entity =>
            {
                entity.ToTable("Employee_position");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Employee__737584F6121BD772")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

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
                    .HasName("UQ__Material__78A1A19D2DCA0491")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Number).HasMaxLength(16);

                entity.Property(e => e.Receipt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MaterialUnits>(entity =>
            {
                entity.ToTable("Material_units");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Material__737584F6A82DA201")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.HasOne(d => d.Fault)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.FaultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_fk2");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_fk1");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_fk0");
            });

            modelBuilder.Entity<OrderFault>(entity =>
            {
                entity.ToTable("Order_fault");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_status");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Order_st__737584F65815BAF6")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(e => e.RegNumber)
                    .HasName("UQ__Vehicle__18B201F636734836")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RegNumber)
                    .IsRequired()
                    .HasColumnName("Reg_number")
                    .HasMaxLength(16);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_fk1");

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
                    .HasName("UQ__Vehicle___737584F62C8CFEDB")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.ToTable("Vehicle_model");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Vehicle___737584F6D60374B5")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

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
