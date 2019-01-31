namespace RepairsManager.Dal.Models
{
    public partial class DefecationResponsible
    {
        public int Id { get; set; }
        public int DefecationId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Defecation Defecation { get; set; }
    }
}
