using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticModel
{
    public partial class FirearmType
    {
        public override bool Equals(object obj)
        {
            return obj is FirearmType type &&
                   TypeName == type.TypeName &&
                   EqualityComparer<List<Firearm>>.Default.Equals(Firearm, type.Firearm);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TypeName, Firearm);
        }

        public override string ToString()
        {
            return $"{TypeName}";
        }

        
    }
}
