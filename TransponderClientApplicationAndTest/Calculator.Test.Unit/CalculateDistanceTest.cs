using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication.Calculator;



namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculateDistanceTest
    {
        [TestCase(50, 40, 60, 80, 22.361)]
        public void CalcDistance_xcor1_ycor1_xcor2_ycor2_ReturnResult(int a, int b, int c, int d, int e)
        {
            // Arrange
            var uut = new CalculateDistance();

            // Act & Assert
            Assert.That(uut.CalcDistance(a, b, c, d), Is.EqualTo(e));
        }
    }
}
