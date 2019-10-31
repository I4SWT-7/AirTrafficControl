using System;
using System.Collections.Generic;
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

        //private FlyTransformer _uut;

        private ITransformer _fakeITransformer;
        

        [SetUp]
        public void SetUp()
        {
            // Make a Fake ITransformer
            _fakeITransformer = Substitute.For<ITransformer>();
            // Inject the fake TDR
            //_uut = new FlyTransformer;
        }

        [Test]
        public void FlyTransformer_TransformData_converts_correctly()
        {
            //Make a test Fly object
            Fly testfly1 = new Fly();
            //testfly1.date = DateTime.Now;

            Fly testfly2 = new Fly();
            testfly2.date = testfly1.date;


            _fakeITransformer.TransformData(testfly1);
            Assert.AreEqual(testfly2.date.ToString("dd. MMM yyyy HH:mm:ss:fff"), _fakeITransformer.TransformData(testfly1).ToString());


            //Assert.AreEqual("31. okt 2019 15:50:23:555", testfly1.date.ToString());

        }
        /*
        [Test]
        public void FlyTransformer_correct_format_conversion()
        { }

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
