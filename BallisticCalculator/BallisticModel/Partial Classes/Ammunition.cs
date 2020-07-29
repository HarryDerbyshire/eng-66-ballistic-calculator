using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticModel
{
    public partial class Ammunition
    {
        public override string ToString()
        {
            return $"{AmmunitionName}: Coefficient: {Coefficient} Grain: {Grain} Diameter: {Diameter}mm";
        }

        
    }
}
