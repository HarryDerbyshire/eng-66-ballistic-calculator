using System;
using System.Collections.Generic;
using System.Text;
using BallisticModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;

namespace BallisticController
{
    public class Create
    {
     
        public void AddFirearm(string firearmName, int muzzleVelocity, int typeID, int ammunitionID)
        {

            using (var db = new BallisticContext())
            {
                db.Add(new Firearm { FirearmName = firearmName, MuzzleVelocity = muzzleVelocity, FirearmTypeID = typeID, AmmunitionID = ammunitionID });
                db.SaveChanges();
            }
        }
      
        public void AddAmmunition(string ammunitionName, float coefficient, float grain, float diameter)
        {
            using (var db = new BallisticContext())
            {
                db.Add(new Ammunition { AmmunitionName = ammunitionName, Coefficient = coefficient, Grain = grain, Diameter = diameter });
                db.SaveChanges();
            }
        }

        public void AddFirearmType(string typeName)
        {
            using (var db = new BallisticContext())
            {
                db.Add(new FirearmType { TypeName = typeName });
                db.SaveChanges();
            }
        }

       
       
    }
}
