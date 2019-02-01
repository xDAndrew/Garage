using Microsoft.EntityFrameworkCore;
using RepairsManager.Dal.Context.Configurations;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context
{
    public class RepairsManagerContext : DbContext
    {
        public RepairsManagerContext(DbContextOptions<RepairsManagerContext> options) : base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.ApplyConfiguration(new CommissionSetting());
            modelBuilder.ApplyConfiguration(new CommissionResponsibleSettings());
            modelBuilder.ApplyConfiguration(new DefecationSettings());
            modelBuilder.ApplyConfiguration(new DefecationPartSettings());
            modelBuilder.ApplyConfiguration(new DefecationResponsibleSettings());
            modelBuilder.ApplyConfiguration(new DepreciationSettings());
            modelBuilder.ApplyConfiguration(new EmployeeSettings());
            modelBuilder.ApplyConfiguration(new EmployeeDepartmentSettings());
            modelBuilder.ApplyConfiguration(new EmployeePositionSettings());
            modelBuilder.ApplyConfiguration(new MaterialSettings());
            modelBuilder.ApplyConfiguration(new MaterialPartySettings());
            modelBuilder.ApplyConfiguration(new MaterialUnitsSettings());
            modelBuilder.ApplyConfiguration(new OrderSettings());
            modelBuilder.ApplyConfiguration(new OrderFaultSettings());
            modelBuilder.ApplyConfiguration(new OrderStatusSettings());
            modelBuilder.ApplyConfiguration(new VehicleSettings());
            modelBuilder.ApplyConfiguration(new VehicleMarkSettings());
            modelBuilder.ApplyConfiguration(new VehicleModelSettings());
        }
    }
}
