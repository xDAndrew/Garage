using System;

namespace RepairsManager.WriteOffModule.Models
{
    public class Commission
    {
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public Member Chairman { get; set; }
        public Member[] Members { get; set; }
    }
}
