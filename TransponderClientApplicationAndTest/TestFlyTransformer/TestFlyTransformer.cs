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

        [Test]
        public void FlyTransformer_TransformData_called_when_ReceieveData()
        {
            
            // Act
            _uut.ReceiveData();

            // Assert on the mock - was the heater called correctly
            Assert.That(_uut.TransformData, Is.EqualTo(1));
        }

        /*
        [Test]
        public void FlyTransformer_receives_data()
        { }

        [Test]
        public void FlyTransformer_sends_data()
        {

        }
        */
    }
}
