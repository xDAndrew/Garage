using System;

namespace RepairsManager.WriteOffModule.Models.Materials
{
    public class Party
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public double Count { get; set; }
    }
}
