namespace RepairsManager.Dal.Models
{
    public partial class CommissionResponsible
    {
        public int Id { get; set; }
        public int CommissionId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Commission Commission { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
