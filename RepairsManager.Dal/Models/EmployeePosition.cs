using System.Collections.Generic;

namespace RepairsManager.Dal.Models
{
    public partial class EmployeePosition
    {
        public EmployeePosition()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
