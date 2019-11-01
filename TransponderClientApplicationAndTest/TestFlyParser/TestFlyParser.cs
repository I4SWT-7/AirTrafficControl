using System;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.Core.Smtp;
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
        List<Fly> assertfly = new List<Fly>();
        List<string> testData = new List<string>();
        public event EventHandler<RawTransponderDataEventArgs> TransponderDataTestReady;


        [SetUp]
        public void Setup()
        {
            // Make a fake Transponder Data Receiver
            receiver = Substitute.For<ITransponderReceiver>();
            // Inject the fake TDR
            uut = new FlyParser(receiver);

        // Setup test data
        testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");
            Fly fly1 = new Fly("ATR423", 39045, 12932, 14000);
            Fly fly2 = new Fly("BCD123", 10005, 85890, 12000);
            Fly fly3 = new Fly("XYZ987", 25059, 75654, 4000);
            fly1.date = DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", null);
            fly2.date = DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", null);
            fly3.date = DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", null);
            assertfly.Add(fly1);
            assertfly.Add(fly2);
            assertfly.Add(fly3);
        }

        //[Test]
        //public void TestReceive()
        //{
        //    // Act: Trigger the fake object to execute event invocation
        //    receiver.TransponderDataReady
        //        += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

        //    Assert.That(uut.FlyList, Is.EqualTo(assertfly));
        //}

        [Test]
        public void TestTag()
        {
            ReceptionHelp(assertfly, testData);

            //Help function
            void ReceptionHelp(List<Fly> expectedResult, List<string> inputdata)
            {
                List<Fly> returnedfly = new List<Fly>();
                returnedfly = uut.Parsedata(inputdata);
                for (int i = 0; i < expectedResult.Count; i++)
                {
                    Assert.That(returnedfly[i].Tag, Is.EqualTo(expectedResult[i].Tag));
                }
            }
        }
        [Test]
        public void TestX()
        {
            ReceptionHelp(assertfly, testData);

            //Help function
            void ReceptionHelp(List<Fly> expectedResult, List<string> inputdata)
            {
                List<Fly> returnedfly = new List<Fly>();
                returnedfly = uut.Parsedata(inputdata);
                for (int i = 0; i < expectedResult.Count; i++)
                {
                    Assert.That(returnedfly[i].xcor, Is.EqualTo(expectedResult[i].xcor));
                }
            }
        }
        [Test]
        public void Testy()
        {
            ReceptionHelp(assertfly, testData);

            //Help function
            void ReceptionHelp(List<Fly> expectedResult, List<string> inputdata)
            {
                List<Fly> returnedfly = new List<Fly>();
                returnedfly = uut.Parsedata(inputdata);
                for (int i = 0; i < expectedResult.Count; i++)
                {
                    Assert.That(returnedfly[i].ycor, Is.EqualTo(expectedResult[i].ycor));
                }
            }
        }
        [Test]
        public void Testz()
        {
            ReceptionHelp(assertfly, testData);

            //Help function
            void ReceptionHelp(List<Fly> expectedResult, List<string> inputdata)
            {
                List<Fly> returnedfly = new List<Fly>();
                returnedfly = uut.Parsedata(inputdata);
                for (int i = 0; i < expectedResult.Count; i++)
                {
                    Assert.That(returnedfly[i].zcor, Is.EqualTo(expectedResult[i].zcor));
                }
            }
        }
        [Test]
        public void Testdate()
        {
            ReceptionHelp(assertfly, testData);

            //Help function
            void ReceptionHelp(List<Fly> expectedResult, List<string> inputdata)
            {
                List<Fly> returnedfly = new List<Fly>();
                returnedfly = uut.Parsedata(inputdata);
                for (int i = 0; i < expectedResult.Count; i++)
                {
                    Assert.That(returnedfly[i].date.ToString(), Is.EqualTo(expectedResult[i].date.ToString()));
                }
            }
        }
    }
}
