using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticModel
{
    public class FirearmType
    {
        public int FirearmTypeID { get; set; }
        public string TypeName { get; set; }

        public List<Firearm> Firearm { get; } = new List<Firearm>();
    }
}
