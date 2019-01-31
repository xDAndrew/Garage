using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class Employee
    {
        public Employee()
        {
            CommissionResponsible = new HashSet<CommissionResponsible>();
            Defecation = new HashSet<Defecation>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }

        public virtual EmployeeDepartment Department { get; set; }
        public virtual EmployeePosition Position { get; set; }
        public virtual ICollection<CommissionResponsible> CommissionResponsible { get; set; }
        public virtual ICollection<Defecation> Defecation { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
