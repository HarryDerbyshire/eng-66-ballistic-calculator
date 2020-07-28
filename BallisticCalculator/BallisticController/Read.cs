using System;
using System.Collections.Generic;
using System.Text;
using BallisticModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace BallisticController
{
    class Read
    {
        #region Firearm Data
        public static List<Firearm> RetrieveAllFirearm()
        {
            using (var db = new BallisticContext())
            {
                return db.Firearms
                    .Include(a => a.Ammunition)
                    .Include(ft => ft.FirearmType)
                    .ToList<Firearm>();
            }
        }

        public static List<Firearm> RetrieveSpecificFirearm(int userFirearmID)
        {
            using (var db = new BallisticContext())
            {
                return db.Firearms
                    .Include(a => a.Ammunition)
                    .Include(ft => ft.FirearmType)
                    .Where(f => f.FirearmID == userFirearmID)
                    .ToList<Firearm>();
            }
        }
        #endregion
        #region Ammunition Data
        public static List<Ammunition> RetrieveAllAmmunition()
        {
            using (var db = new BallisticContext())
            {
                return db.Ammunition
                    .ToList<Ammunition>();
            }
        }
        #endregion
        #region Type Data
        public static List<FirearmType> RetrieveAllFirearmType()
        {
            using (var db = new BallisticContext())
            {
                return db.FirearmTypes
                    .ToList<FirearmType>();
            }
        }

        #endregion
    }
}
