using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication;



namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculateDistanceTest
    {

        //Fly Fly1 = new Fly("TAG123", 40, 60, 500);
        //Fly Fly2 = new Fly("TAG321", 60, 80, 1000);

        [Test]
        public void CalcDistance_ShortDistance_ReturnResult()
        {
            Fly Fly1 = new Fly("TAG123", 40, 60, 500);
            Fly Fly2 = new Fly("TAG321", 60, 80, 1000);
            // Arrange
            var uut = new CalculateDistance();

            // Act & Assert
            Assert.That(uut.CalcDistance(Fly1, Fly2), Is.EqualTo(28.2843));
        }

        [Test]
        public void CalcDistance_LongDistance_ReturnResult()
        {
            Fly Fly1 = new Fly("TAG123", 40, 60, 500);
            Fly Fly2 = new Fly("TAG321", 9000, 9000, 1000);
            //Arrange
            var uut = new CalculateDistance();

            //Act & Assert
            Assert.That(uut.CalcDistance(Fly1, Fly2), Is.EqualTo(12657.2193));
        }
    }
}
