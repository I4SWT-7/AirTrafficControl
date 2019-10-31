using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;
using NSubstitute;
using NUnit.Framework;

namespace TestFlyParser
{
    public class TestFlyParser
    {
        private IParser _FakeIParser;
        private FlyTransformer _fakeTransformer;

        [SetUp]
        public void Setup()
        {
            // Make a fake Transponder Data Receiver
            _FakeIParser = Substitute.For<IParser>();
            // Inject the fake TDR
            _fakeTransformer = new F(_FakeIParser);
        }


        [Test]
        public void TestReception()
        {
            // Setup test data
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            // Assert something here or use an NSubstitute Received
        }
    }
}
