using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using BallisticModel;
using Microsoft.EntityFrameworkCore;

namespace BallisticController
{
    public class Program
    {
        static void Main(string[] args)
        {
          
            foreach (var item in Read.RetrieveAllFirearm())
            {
                Console.WriteLine($"{item.FirearmName} {item.Ammunition.AmmunitionName} {item.FirearmType.TypeName}");
            }

          
            foreach(var item in Read.RetrieveAllAmmunition())
            {
                Console.WriteLine($"{item.AmmunitionID} {item.AmmunitionName}");
            }
            
            foreach (var item in Read.RetrieveAllFirearmType())
            {
                Console.WriteLine($"{item.FirearmTypeID} {item.TypeName}");
            }

            foreach(var item in Read.RetrieveSpecificFirearm(2))
            {
                Console.WriteLine($"{item.FirearmName} {item.Ammunition.AmmunitionName} {item.FirearmType.TypeName}");
            }
            
        }

    }

  
}
