using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using NUnit.Framework;
using TransponderReceiverApplication;
using NSubstitute;



namespace TestFlyTransformer
{
    [TestFixture]
    public class TestFlyTransformer
    {

        private FlyTransformer _uut;
        private IParser _fakeIParser;
        private List<Fly> _fakeFlyList;
        private Fly testfly1;


        [SetUp]
        public void SetUp()
        {
            // Make a Fake IParser
            _fakeIParser = Substitute.For<IParser>();
            // Inject the fake IParser
            _uut = new FlyTransformer(_fakeIParser);
            _fakeFlyList = new List<Fly>();
        }

        [Test]
        public void FlyTransformer_TransformData_converts_correctly()
        {
            //Make a test Fly object
            testfly1 = new Fly();

            //Make teststring to assert to
            string teststring = testfly1.date.ToString("dd. MMM yyyy HH:mm:ss:fff ");
            
            //Assertion to check if TransformData transforms correctly
            Assert.AreEqual(teststring, _uut.TransformData(testfly1).date.ToString());
        }

        
        public void FlyTransformer_TransformData_called_when_ReceieveData()
        {
        }

        
        [Test]
        public void FlyTransformer_receives_data(/*List<Fly> newFlyList*/)
        {
            _fakeFlyList.Add(testfly1);


            _fakeIParser.ParserDataReady +=
                Raise.EventWith<RawParserDataEventArgs>(this, new RawParserDataEventArgs(_fakeFlyList) /*{Flylist = newFlyList}*/);

            Assert.That(_uut.TransFlyList[0] == testfly1);

        }
        /*
        [Test]
        public void FlyTransformer_sends_data()
        {

        }
        */
    }
}
