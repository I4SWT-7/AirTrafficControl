using System;
using System.Collections.Generic;
using System.Configuration;
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
            //testData.Add("BCD123;10005;85890;12000;20151006213456789");
            //testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            //Setup expected result
            List<Fly> assertfly = new List<Fly>();
            Fly fly1 = new Fly("ATR423", 39045, 12932, 14000);
            assertfly.Add(fly1);
            fly1.date = DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", null);
            ReceptionHelp(assertfly, testData);

            //Help function
            void ReceptionHelp(List<Fly> expectedResult, List<string> inputdata)
            {
                List<Fly> returnedfly = new List<Fly>();
                returnedfly = uut.Parsedata(inputdata);
                for(int i =0; i < expectedResult.Count; i++)
                {
                    Assert.That(returnedfly[0].Tag, Is.EqualTo(expectedResult[i].Tag));
                    Assert.That(returnedfly[0].xcor, Is.EqualTo(expectedResult[i].xcor));
                    Assert.That(returnedfly[0].xcor, Is.EqualTo(expectedResult[i].ycor));
                    Assert.That(returnedfly[0].zcor, Is.EqualTo(expectedResult[i].zcor));
                    Assert.That(returnedfly[0].date.ToString(), Is.EqualTo(expectedResult[i].date.ToString()));

                }


            }

            // Assert something here or use an NSubstitute Received
        }
    }
}
