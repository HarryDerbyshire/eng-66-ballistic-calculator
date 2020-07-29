using System;
using System.Collections.Generic;
using System.Text;
using BallisticModel;

namespace BallisticController
{
    public class Calculation
    {
        public static float CrossSectionalArea(float diameter)
        {
            var diameterInMetres = diameter / 1000;
            var radius = diameterInMetres / 2;
            return Convert.ToSingle(Math.PI * (radius * radius));
        }

        public static float GrainToKilogram(float grain)
        {
            return Convert.ToSingle(grain * 0.00006479891);
        }

        public static float Deceleration(float diameter, float coefficient, float grain, float velocity)
        {
            var constants = Read.ReadDefaults();

            
            float mass = GrainToKilogram(grain);
            float area = CrossSectionalArea(diameter);

            return Convert.ToSingle(area * coefficient * constants.AirDensity * (velocity * velocity)) / (2 * mass);
        }
    }
}
