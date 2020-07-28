using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BallisticModel;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace BallisticController
{
    class Update
    {

        public static void UpdateFirearm(int firearmID, string firearmName, int muzzleVelocity, int typeID, int ammunitionID)
        {
            using (var db = new BallisticContext())
            {
                var SelectedFirearm = db.Firearms.Where(f => f.FirearmID == firearmID).FirstOrDefault();

                SelectedFirearm.FirearmName = firearmName;
                SelectedFirearm.MuzzleVelocity = muzzleVelocity;
                SelectedFirearm.FirearmTypeID = typeID;
                SelectedFirearm.AmmunitionID = ammunitionID;
                db.SaveChanges();
            }
        }

        public static void UpdateAmmunition(int ammunitionID, string ammunitionName, float coefficient, float grain, float diameter)
        {
            using (var db = new BallisticContext())
            {
                var SelectedAmmunition = db.Ammunition.Where(a => a.AmmunitionID == ammunitionID).FirstOrDefault();

                SelectedAmmunition.AmmunitionName = ammunitionName;
                SelectedAmmunition.Coefficient = coefficient;
                SelectedAmmunition.Grain = grain;
                SelectedAmmunition.Diameter = diameter;
                db.SaveChanges();
            }
        }

        public static void UpdateFirearmType(int typeID, string typeName)
        {
            using (var db = new BallisticContext())
            {
                var SelectedFirearmType = db.FirearmTypes.Where(ft => ft.FirearmTypeID == typeID).FirstOrDefault();

                SelectedFirearmType.TypeName = typeName;
                db.SaveChanges();
            }
        }

        public static void UpdateGravity(float gravity)
        {
            string path = "C:\\github\\eng-66-ballistic-calculator\\BallisticCalculator\\BallisticModel\\Defaults.json";
            string jsonString = File.ReadAllText(path);
            var jsonObject = JsonConvert.DeserializeObject<Default>(jsonString);

            jsonObject.Gravity = gravity;

            jsonString = JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText(path, jsonString);
        }

        public static void UpdateAirDensity(float airDensity)
        {
            string path = "C:\\github\\eng-66-ballistic-calculator\\BallisticCalculator\\BallisticModel\\Defaults.json";
            string jsonString = File.ReadAllText(path);
            var jsonObject = JsonConvert.DeserializeObject<Default>(jsonString);

            jsonObject.AirDensity = airDensity;

            jsonString = JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText(path, jsonString);
        }
    }
}
