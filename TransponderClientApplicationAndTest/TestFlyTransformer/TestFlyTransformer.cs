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
        private RawTransformerDataEventArgs _testTransformerDataEventArgs;

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


            // Setting _testTransformerDataEventArgs to null
            _testTransformerDataEventArgs = null;

            // Setting up event listener to check event
            _uut.TransformerDataReady += (o, args) => { _testTransformerDataEventArgs = args; };

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
            

            _fakeIParser.ParserDataReady +=
                Raise.EventWith<RawParserDataEventArgs>(this, new RawParserDataEventArgs(_testFlyList));
            Assert.That(_uut.TransFlyList, Is.EqualTo(_testFlyList));

        }

        [Test]
        public void Transformer_event_fired()
        {
            _uut.ReceiveData(this,new RawParserDataEventArgs(_testFlyList));
            Assert.That(_testTransformerDataEventArgs, Is.Not.Null);
        }

        [Test]
        public void Transformer_event_fired_with_correct_list()
        {
            _testFlyList.Add(testfly1);
            _uut.ReceiveData(this, new RawParserDataEventArgs(_testFlyList));
            Assert.That(_testTransformerDataEventArgs.TransFlyList, Is.EqualTo(_testFlyList));
        }

    }
}
