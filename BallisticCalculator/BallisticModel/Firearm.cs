using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticModel
{
    public partial class Firearm
    {
        public int FirearmID { get; set; }
        public int FirearmTypeID { get; set; }
        public int AmmunitionID { get; set; }
        public string FirearmName { get; set; }
        public int MuzzleVelocity { get; set; }

        public virtual Ammunition Ammunition { get; set; }
        public virtual FirearmType FirearmType { get; set; }

    
    }

    
}
