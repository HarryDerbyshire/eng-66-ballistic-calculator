using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticModel
{
    public class Ammunition
    {
        public int AmmunitionID { get; set; }
        public string AmmunitionName { get; set; }
        public float Coefficient { get; set; }
        public float Grain { get; set; }
        public float Diameter { get; set; }

        public List<Firearm> Firearm { get; } = new List<Firearm>(); 
    }
}
