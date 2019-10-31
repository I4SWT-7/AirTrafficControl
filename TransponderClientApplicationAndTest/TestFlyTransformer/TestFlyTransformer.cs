using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        [SetUp]
        public void SetUp()
        {
            // Make a Fake IParser
            _fakeIParser = Substitute.For<IParser>();
            // Inject the fake IParser
            _uut = new FlyTransformer(_fakeIParser);
        }

        [Test]
        public void FlyTransformer_TransformData_converts_correctly()
        {
            //Make a test Fly object
            Fly testfly1 = new Fly();

            //Make teststring to assert to
            string teststring = testfly1.date.ToString("dd. MMM yyyy HH:mm:ss:fff ");
            
            //Assertion to check if TransformData transforms correctly
            Assert.AreEqual(teststring, _uut.TransformData(testfly1).date.ToString());
        }

        
        public void FlyTransformer_TransformData_called_when_ReceieveData()
        {
        }

        
        
        public void FlyTransformer_receives_data(List<Fly> newFlyList)
        {

            _fakeIParser.ParserDataReady +=
                Raise.EventWith<RawParserDataEventArgs>(this, new RawParserDataEventArgs(_fakeFlyList) {Flylist = newFlyList});

            Assert.That(_uut.TransFlyList, Is.EqualTo(newFlyList));

        }
        /*
        [Test]
        public void FlyTransformer_sends_data()
        {

        }
        */
    }
}
