namespace RepairsManager.Dal.Models
{
    public partial class Depreciation
    {
        public int Id { get; set; }
        public string Organization { get; set; }
        public int DepartmentId { get; set; }
        public int ApprovedId { get; set; }
        public string Number { get; set; }
        public int CommissionId { get; set; }
        public int MaterialId { get; set; }

        public virtual Commission Commission { get; set; }
        public virtual EmployeeDepartment Department { get; set; }
        public virtual Material Material { get; set; }
    }
}
