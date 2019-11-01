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
        [TestCase()]
        public void CalcCourse_xcor1_ycor1_xcor2_ycor2(int a, int b, int c, int d, int e)
        {
            //Arrange
            var uut = new CalculateCourse();

            // Act & Assert
            Assert.That(uut.CalcCourse(a, b, c, d), Is.EqualTo(e));
        }
    }
}
