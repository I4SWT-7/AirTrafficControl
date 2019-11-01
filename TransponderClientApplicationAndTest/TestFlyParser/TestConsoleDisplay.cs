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
        Fly testfly2 = new Fly("TAG123", 1000, 9000, 1000);

        private double testspeed = 9000;
        private double testcourse = 90;

        private ConsoleDisplay _uut;

        [Test]
        public void ConsoleDisplay_writes_correct_plane()
        {
            _uut = new ConsoleDisplay();
            string teststring =  "Displaying plane with tag:TAG321, x position 9000 meters, y position 9000 meters, altitude: 1000 meters, velocity: 9000 m/s course: 90 degrees ";

            Assert.That(_uut.PrintPlane(testfly, testspeed, testcourse), Is.EqualTo (teststring));
        }
        [Test]
        public void ConsoleDisplay_write_sperationwarning()
        {
            testfly.date = DateTime.ParseExact("20191010232218123", "yyyyMMddHHmmssfff", null);
            testfly2.date = DateTime.ParseExact("20191010232218126", "yyyyMMddHHmmssfff", null);

            _uut = new ConsoleDisplay();
            string teststring = $"SEPERATION WARNING BETWEEN:TAG321 AND TAG123 WITH TIMESTAMPS: 10-10-2019 23:22:18 AND 10-10-2019 23:22:18";
            Assert.That(_uut.PrintSeperationWarning(testfly, testfly2), Is.EqualTo(teststring));
        }
    }
}