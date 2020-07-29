using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BallisticModel;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Internal;

namespace BallisticController
{
    public class Delete
    {
       public void DeleteFirearm(int firearmID)
        {
            using (var db = new BallisticContext())
            {

                var firearmToDelete = db.Firearms.Where(f => f.FirearmID == firearmID).FirstOrDefault();

                if (firearmToDelete !=null)
                {
                    db.Firearms.Remove(firearmToDelete);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteFirearmType(int typeID)
        {
            using (var db = new BallisticContext())
            {
          
                var firearmTypeToDelete = db.FirearmTypes.Where(ft => ft.FirearmTypeID == typeID).FirstOrDefault();

                var firearmToCheck = db.Firearms.Where(f => f.FirearmTypeID == typeID).FirstOrDefault();
              
                if (firearmToCheck == null && firearmTypeToDelete != null)
                {
                    db.FirearmTypes.Remove(firearmTypeToDelete);
                    db.SaveChanges();
                }
              
            }
        }

        public void DeleteAmmunition(int ammunitionID)
        {
            using(var db = new BallisticContext())
            {
                var ammunitionToDelete = db.Ammunition.Where(a => a.AmmunitionID == ammunitionID).FirstOrDefault();

                var firearmToCheck = db.Firearms.Where(f => f.AmmunitionID == ammunitionID).FirstOrDefault();

                if (firearmToCheck == null && ammunitionToDelete != null)
                {
                    db.Ammunition.Remove(ammunitionToDelete);
                    db.SaveChanges();
                }
            }
        }

    }
}
