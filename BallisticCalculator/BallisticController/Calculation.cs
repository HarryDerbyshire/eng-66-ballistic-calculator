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

        public static decimal Deceleration(Firearm currentFirearm, decimal velocity)
        {
            var constants = Read.ReadDefaults();

            
            decimal mass = GrainToKilogram(Convert.ToDecimal(currentFirearm.Ammunition.Grain));
            decimal area = CrossSectionalArea(Convert.ToDecimal(currentFirearm.Ammunition.Diameter));
            //Return (CrossSection * BallisticCoefficient * AirDensity * (Velocity ^ 2)) / (2 * Mass)
            return Convert.ToDecimal(Convert.ToDecimal(area) * Convert.ToDecimal(currentFirearm.Ammunition.Coefficient) * Convert.ToDecimal(constants.AirDensity) * (velocity * velocity)) / (2 * mass);
        }
        public static double AngleInRadians(int angle)
        {
            return Convert.ToDouble(angle * Math.PI / 180);
        }
        public static List<KeyValuePair<decimal, decimal>> Speed(int firearmID, int angle, decimal height, decimal sampleRate, string graphType)
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

            List<KeyValuePair<decimal, decimal>> listCoordTime = new List<KeyValuePair<decimal, decimal>>() { };
            List<KeyValuePair<decimal, decimal>> listCoordDistance = new List<KeyValuePair<decimal, decimal>>() { };

            while (yDistance > 0 && xSpeed > 0)
            {
                newXSpeed = xSpeed - (Deceleration(currentFirearm, xSpeed) * sampleRate);
                newYSpeed = 
                    ySpeed 
                    - 
                    (
                        (
                            Convert.ToDecimal(constants.Gravity) 
                            + 
                            Deceleration(
                                currentFirearm, 
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

                listCoordDistance.Add(new KeyValuePair<decimal, decimal>(xDistance, yDistance));
                listCoordTime.Add(new KeyValuePair<decimal, decimal>(totalTime, yDistance));
            }

           
            if (graphType == "HeightTime")
            {
                return listCoordTime;
            } else
            {
                return listCoordDistance;
            }

            
        }
    }
}
