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
        private IFilter _fakeFilter;

        private FlyTransformer _uut;
        private IParser _fakeIParser;
        private List<Fly> _testFlyList;
        private Fly testfly1 = new Fly();
        private Fly testfly2 = new Fly();


        [SetUp]
        public void SetUp()
        {
            // Make a test Flylist
            _testFlyList = new List<Fly>();
            // Make a Fake IParser
            _fakeIParser = Substitute.For<IParser>();
            // Injection
            _uut = new FlyTransformer(_fakeIParser);

            

        }

        [Test]
        public void FlyTransformer_TransformData_converts_correctly()
        {
            
            //Make teststring to assert to
            string teststring = testfly2.date.ToString("dd. MMM yyyy HH:mm:ss:fff ");
            
            //Assertion to check if TransformData transforms correctly
            Assert.AreEqual(teststring, _uut.TransformData(testfly2).date.ToString());
        }

        

        
        [Test]
        public void FlyTransformer_receives_data()
        {
            
            _testFlyList.Add(testfly1);
            _testFlyList.Add(testfly2);

            _fakeIParser.ParserDataReady +=
                Raise.EventWith<RawParserDataEventArgs>(this, new RawParserDataEventArgs(_testFlyList));
            Assert.That(_uut.TransFlyList, Is.EqualTo(_testFlyList));

        }



    }
}
