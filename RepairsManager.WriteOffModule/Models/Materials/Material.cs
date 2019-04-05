using System;
using System.Collections.Generic;
using System.Text;

namespace RepairsManager.WriteOffModule.Models.Materials
{
    public class Material
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public List<Party> Parties { get; set; } = new List<Party>();
    }
}
