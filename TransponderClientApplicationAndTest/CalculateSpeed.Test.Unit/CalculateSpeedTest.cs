using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication;

namespace CalculateSpeed.Test.Unit
{
    [TestFixture]
    public class CalculateSpeedTest
    {
        Fly Fly1 = new Fly("TAG123", 40, 60, 500);
        Fly Fly2 = new Fly("TAG123", 9000,9000, 1000);
        Fly Fly1NotMoving = new Fly("TAG123", 60, 80, 1000);
        Fly Fly2NotMoving = new Fly("TAG123", 60, 80, 1000);
        [Test]
        public void CalcSpeed_distance_timeStamps_ReturnResult()
        {
            this.Fly1.date = DateTime.ParseExact("20191006233456789", "yyyyMMddHHmmssfff", null);
            this.Fly2.date = DateTime.ParseExact("20191006213456789", "yyyyMMddHHmmssfff", null);
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateSpeed();

            // Act & Assert
            Assert.That(uut.CalcSpeed(Fly1, Fly2), Is.EqualTo(1.76));
        }
        [Test]
        public void CalcSpeed_distance_timeStamps_NoMovement_ReturnResult()
        {
            this.Fly1NotMoving.date = DateTime.ParseExact("20191006233456789", "yyyyMMddHHmmssfff", null);
            this.Fly2NotMoving.date = DateTime.ParseExact("20191006213456789", "yyyyMMddHHmmssfff", null);
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateSpeed();

            // Act & Assert
            Assert.That(uut.CalcSpeed(Fly1NotMoving,Fly2NotMoving), Is.EqualTo(0));
        }
    }

}
