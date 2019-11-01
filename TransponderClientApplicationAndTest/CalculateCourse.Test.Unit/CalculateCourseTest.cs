using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication;

namespace CalculateCourse.Test.Unit
{
    [TestFixture]
    public class CalculateCourseTest
    {
        Fly Fly1 = new Fly("TAG123", 1, 1, 500);
        Fly Fly2 = new Fly("TAG123", 100, 100, 1000);
        [Test]
        public void CalcCourse_45degrees()
        {
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(Fly1, Fly2), Is.EqualTo(45));
        }
        [Test]
        public void CalcCourse_180degrees()
        {
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(Fly1, Fly2), Is.EqualTo(45));
        }
    }
}
