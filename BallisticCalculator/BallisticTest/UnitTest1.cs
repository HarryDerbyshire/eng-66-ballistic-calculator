using NUnit.Framework;
using BallisticController;
using System.Runtime.InteropServices.ComTypes;
using System;

namespace BallisticTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        
        }

        [TestCase(45, 0.785398)]
        [TestCase(0, 0)]
        [TestCase(20, 0.349066)]
        [TestCase(88, 1.53589)]
        [TestCase(6, 0.10472)]
        public void DegreesToRadiansCorrectValue(int degrees, decimal radians)
        {
            decimal Result = Convert.ToDecimal(Calculation.AngleInRadians(degrees));
            decimal Expected = radians;
            Assert.AreEqual(Math.Round(Result, 4), Math.Round(Expected, 4));
        }

        [TestCase(89, 0.0057671)]
        [TestCase(150, 0.00971984)]
        [TestCase(190, 0.0123118)]
        [TestCase(45, 0.00291595)]
        public void GrainToKilogram(int grain, decimal kilogram)
        {
            decimal Result = Calculation.GrainToKilogram(grain);
            decimal Expected = kilogram;
            Assert.AreEqual(Math.Round(Result, 4), Math.Round(Expected, 4));
        }
    }
}