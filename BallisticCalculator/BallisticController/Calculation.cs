using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BallisticModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BallisticController
{
    public class Calculation
    {
        public float Area { get; set; }
        public float Mass { get; set; }
        public Firearm SelectedFirearm { get; }
        
         
        public static decimal CrossSectionalArea(decimal diameter)
        {
            var diameterInMetres = diameter / 1000;
            decimal radius = diameterInMetres / 2;
            return Convert.ToDecimal(Math.PI ) * (radius * radius);
        }

        public static decimal GrainToKilogram(decimal grain)
        {
            return Convert.ToDecimal(grain * 0.00006479891m);
        }

        public static decimal Deceleration(decimal diameter, decimal coefficient, decimal grain, decimal velocity)
        {
            var constants = Read.ReadDefaults();

            
            decimal mass = GrainToKilogram(grain);
            decimal area = CrossSectionalArea(diameter);
            //Return (CrossSection * BallisticCoefficient * AirDensity * (Velocity ^ 2)) / (2 * Mass)
            return Convert.ToDecimal(Convert.ToDecimal(area) * Convert.ToDecimal(coefficient) * Convert.ToDecimal(constants.AirDensity) * (velocity * velocity)) / (2 * mass);
        }
        public static double AngleInRadians(int angle)
        {
            return Convert.ToDouble(angle * Math.PI / 180);
        }
        public static List<KeyValuePair<decimal, decimal>> Speed(int firearmID, int angle, decimal height, decimal sampleRate)
        {
            double angleInRadians = AngleInRadians(angle);
            Read _read;
            _read = new Read();

            Firearm currentFirearm = _read.RetrieveSpecificFirearm(firearmID).FirstOrDefault();
          
            decimal xSpeed = Convert.ToDecimal(currentFirearm.MuzzleVelocity * Math.Cos(angleInRadians));
            decimal ySpeed = Convert.ToDecimal(currentFirearm.MuzzleVelocity * Math.Sin(angleInRadians));
            decimal newYSpeed;
            decimal newXSpeed;
            decimal xDistance =0;
            decimal yDistance = height;
            decimal totalTime = 0;
            var constants = Read.ReadDefaults();

            List<KeyValuePair<decimal, decimal>> listCoord = new List<KeyValuePair<decimal, decimal>>() { };

            while (yDistance > 0 && xSpeed > 0)
            {
                newXSpeed = xSpeed - (Deceleration(Convert.ToDecimal(currentFirearm.Ammunition.Diameter), Convert.ToDecimal(currentFirearm.Ammunition.Coefficient), Convert.ToDecimal(currentFirearm.Ammunition.Grain), xSpeed) * sampleRate);
                newYSpeed = 
                    ySpeed 
                    - 
                    (
                        (
                            Convert.ToDecimal(constants.Gravity) 
                            + 
                            Deceleration(
                                Convert.ToDecimal(currentFirearm.Ammunition.Diameter), 
                                Convert.ToDecimal(currentFirearm.Ammunition.Coefficient), 
                                Convert.ToDecimal(currentFirearm.Ammunition.Grain), 
                                ySpeed
                            )
                       
                         )
                        * 
                        sampleRate
                    )
                ;

                xDistance += ((xSpeed + newXSpeed) / 2) * sampleRate;
                yDistance += ((ySpeed + newYSpeed) / 2) * sampleRate;

                totalTime += sampleRate;

                xSpeed = newXSpeed;
                ySpeed = newYSpeed;

                //listCoord.Add(new KeyValuePair<decimal, decimal>(xDistance, yDistance));
                listCoord.Add(new KeyValuePair<decimal, decimal>(totalTime, yDistance));
            }




            return listCoord;
        }
    }
}
