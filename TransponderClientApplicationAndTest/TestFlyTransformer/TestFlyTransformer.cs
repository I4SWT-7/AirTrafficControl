//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using TransponderReceiverApplication;
//using NSubstitute;
//using TransponderReceiverApplication;


//namespace TestFlyTransformer
//{
//    [TestFixture]
//    public class TestFlyTransformer
//    {

//        //private FlyTransformer _uut;

//        private ITransformer _fakeITransformer;
        
        

//        [SetUp]
//        public void SetUp()
//        {
//            // Make a Fake ITransformer
//            _fakeITransformer = Substitute.For<ITransformer>();
//            // Inject the fake TDR
//        }

//        [Test]
//        public void FlyTransformer_TransformData_converts_correctly()
//        {
//            var uut = _fakeITransformer;
//            //Make a test Fly object
//            Fly testfly1 = new Fly();
//            testfly1.date = DateTime.Now;

//            //Make teststring to assert to
//            string teststring = testfly1.date.ToString("dd. MMM yyyy HH:mm:ss:fff");

//            Assert.AreEqual(teststring, uut.TransformData(testfly1).ToString());

//            /*
//            _fakeITransformer.TransformData(testfly1);
//            var testtime = DateTime.ParseExact("12/02/21 10:56:09:555", "yy/MM/dd HH:mm:ss:fff",
//                CultureInfo.InvariantCulture
//            ).ToString("dd. MMM yyyy HH:mm:ss:fff");

//            Assert.AreEqual(testtime, testfly1.date.ToString("dd. MMM yyyy HH:mm:ss:fff"));
//            */
//        }
//        /*
//        [Test]
//        public void FlyTransformer_correct_format_conversion()
//        { }

//        [Test]
//        public void FlyTransformer_receives_data()
//        { }

//        [Test]
//        public void FlyTransformer_sends_data()
//        {

//        }
//        */
//    }
//}
