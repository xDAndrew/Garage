using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class EmployeeDepartment
    {
        public EmployeeDepartment()
        {
            Depreciation = new HashSet<Depreciation>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Depreciation> Depreciation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
