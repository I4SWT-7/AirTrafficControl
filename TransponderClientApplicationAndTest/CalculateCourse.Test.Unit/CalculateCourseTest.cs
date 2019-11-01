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
        Fly Fly3 = new Fly("TAG123", 1, 1, 500);
        Fly Fly4 = new Fly("TAG123", 1, 100, 1000);
        Fly Fly5 = new Fly("TAG123", 1, 1, 500);
        Fly Fly6 = new Fly("TAG123", 1, -100, 1000);
        Fly Fly7 = new Fly("TAG123", 1, 1, 500);
        Fly Fly8 = new Fly("TAG123", 100, 1, 1000);
        Fly Fly9 = new Fly("TAG123", 1, 1, 500);
        Fly Fly10 = new Fly("TAG123", -100, 1, 1000);
        [Test]
        public void CalcCourse_NorthWest()
        {
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(Fly1, Fly2), Is.EqualTo(45));
        }
        [Test]
        public void CalcCourse_North()

        {
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(Fly3, Fly4), Is.EqualTo(0));
        }
        [Test]
        public void CalcCourse_South()
        {
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(Fly5, Fly6), Is.EqualTo(180));
        }
        [Test]
        public void CalcCourse_West()
        {
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(Fly7, Fly8), Is.EqualTo(90));
        }
        [Test]
        public void CalcCourse_East()
        {
            //Arrange
            var uut = new TransponderReceiverApplication.CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(Fly9, Fly10), Is.EqualTo(270));
        }
    }
}

