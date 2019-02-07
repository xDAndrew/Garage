namespace RepairsManager.WebAPI.Models
{
    public class VehicleEndpointModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string MarkName { get; set; }
        public string RegNumber { get; set; }
    }
}
