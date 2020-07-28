using System;
using System.Collections.Generic;
using System.Text;
using BallisticModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BallisticController
{
    public class Read
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

        public static List<Ammunition> RetrieveSpecificAmmunition(int userAmmunitionID)
        {
            using (var db = new BallisticContext())
            {
                return db.Ammunition.Where(a => a.AmmunitionID == userAmmunitionID).ToList<Ammunition>();
    
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

        public static List<FirearmType> RetrieveSpecificFirearmType(int userTypeID)
        {
            using (var db = new BallisticContext())
            {
                return db.FirearmTypes.Where(ft => ft.FirearmTypeID == userTypeID).ToList<FirearmType>();
            }
        }
        #endregion

        #region JSON
        public static Default ReadDefaults()
        {
            string jsonString = File.ReadAllText("C:\\github\\eng-66-ballistic-calculator\\BallisticCalculator\\BallisticModel\\Defaults.json");
            return JsonConvert.DeserializeObject<Default>(jsonString);
            
        }
        
        #endregion
    }


}
