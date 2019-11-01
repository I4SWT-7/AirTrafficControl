using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication;
namespace TestFlyParser
{
    [TestFixture]
    class TestConsoleDisplay
    {
        
        Fly testfly = new Fly("TAG321", 9000, 9000, 1000);
        private double testspeed = 9000;
        private double testcourse = 90;

        private ConsoleDisplay _uut;

        [Test]
        public void ConsoleDisplay_writes_correct_plane()
        {
            _uut = new ConsoleDisplay();
            string teststring =  "Displaying plane with tag:TAG321, x position 9000meters, y position 9000 meters, altitude: 1000, velocity: 9000 course: 90 degrees ";
            _uut.PrintPlane(testfly, testspeed, testcourse);
            Assert.That(_uut.PrintPlane(testfly, testspeed, testcourse), Is.EqualTo (teststring));
        }
    }
}
