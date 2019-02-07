namespace RepairsManager.Dal.Models
{
    public partial class RepairPart
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int MaterialId { get; set; }
        public int Amount { get; set; }
        public string Work { get; set; }

        public virtual Material Material { get; set; }
        public virtual Repair Repair { get; set; }
    }
}
