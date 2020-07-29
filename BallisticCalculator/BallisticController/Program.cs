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
            //Console.WriteLine(Calculation.CrossSectionalArea(5.56f));
            //Console.WriteLine(Calculation.Deceleration());
            //Create.AddFirearm("Plz delete me", 800, 7, 7);
            //Delete.DeleteFirearm(100);
            //Create.AddAmmunition("I need updating", 0.138f, 123, 7.62f);
            //Create.AddFirearmType("I want to be deleted");
            //Delete.DeleteFirearm(1015);
            //Create.AddFirearmType("Plz update me");
            //Delete.DeleteFirearm(1010);
            //Delete.DeleteFirearmType(1009);
            //Create.AddFirearm("Linked type", 790, 7, 1009);
            //Delete.DeleteFirearm(1005);
            //Delete.DeleteFirearmType(1007);
            //Create.AddAmmunition("MethodSyntax", 0.89f, 145, 9f);
            //Delete.DeleteAmmunition(1009);
            //Delete.DeleteFirearm(1008);
            //Delete.DeleteAmmunition(7);
            


            //foreach (var item in Read.RetrieveSpecificFirearm(1015))
            //{
            //    Update.UpdateFirearm(item.FirearmID, "I have been updated", item.MuzzleVelocity, item.FirearmTypeID, item.AmmunitionID);
            //}

            //foreach(var item in Read.RetrieveSpecificAmmunition(1010))
            //{
            //    Update.UpdateAmmunition(item.AmmunitionID, "I have been updated", item.Coefficient, item.Grain, item.Diameter);
            //}

            //foreach(var item in Read.RetrieveSpecificFirearmType(1010))
            //{
            //    Update.UpdateFirearmType(item.FirearmTypeID, "I hath been updated");
            //}

            //foreach (var item in Read.RetrieveAllFirearm())
            //{
            //    Console.WriteLine($"{item.FirearmName} {item.Ammunition.AmmunitionName} {item.FirearmType.TypeName}");
            //}

            //foreach(var item in Read.RetrieveAllAmmunition())
            //{
            //    Console.WriteLine($"{item.AmmunitionID} {item.AmmunitionName}");
            //}

            //foreach (var item in Read.RetrieveAllFirearmType())
            //{
            //    Console.WriteLine($"{item.FirearmTypeID} {item.TypeName}");
            //}

            //foreach(var item in Read.RetrieveSpecificFirearm(2))
            //{
            //    Console.WriteLine($"{item.FirearmName} {item.Ammunition.AmmunitionName} {item.FirearmType.TypeName}");
            //}

            //Console.WriteLine(Read.ReadDefaults().AirDensity);
            //Update.UpdateGravity(10);
            //Update.UpdateAirDensity(1.4f);

        }

    }

  
}
