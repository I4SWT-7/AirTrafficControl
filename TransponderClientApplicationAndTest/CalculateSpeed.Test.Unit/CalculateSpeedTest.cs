using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication.Calculator;

namespace CalculateSpeed.Test.Unit
{
    [TestFixture]
    public class CalculateSpeedTest
    {
        [TestCase(1000, 10, 100)]
        public void CalcSpeed_distance_timeStamps_ReturnResult(int a, int b, int c)
        {
            //Arrange
            var uut = new TransponderReceiverApplication.Calculator.CalculateSpeed();

            // Act & Assert
            Assert.That(uut.CalcSpeed(a, b), Is.EqualTo(c));
        }
    }

}
