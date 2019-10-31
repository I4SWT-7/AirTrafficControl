using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace TestFlyParser
{
    [TestFixture]
    public class TestFlyParser
    {
        private ITransponderReceiver receiver;
        private FlyParser uut;

        [SetUp]
        public void Setup()
        {
            // Make a fake Transponder Data Receiver
            receiver = Substitute.For<ITransponderReceiver>();
            // Inject the fake TDR
            uut = new FlyParser(receiver);
        }

        [Test]
        public void TestReception()
        {
            // Setup test data
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
           // testData.Add("BCD123;10005;85890;12000;20151006213456789");
           // testData.Add("XYZ987;25059;75654;4000;20151006213456789");
            List<Fly> assertfly = new List<Fly>();
            Fly fly1 = new Fly();
            fly1.Tag = "ATR423";
            fly1.xcor = 39045;
            fly1.ycor = 12932;
            fly1.zcor = 14000;
            fly1.date = DateTime.Parse("20151006213456789");
            assertfly.Add(fly1);


            Assert.That(uut.Parsedata(testData), Is.EqualTo(assertfly));
            // Assert something here or use an NSubstitute Received
        }
    }
}
