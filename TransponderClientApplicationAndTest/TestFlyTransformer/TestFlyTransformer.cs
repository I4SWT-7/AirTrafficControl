using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication;


namespace TestFlyTransformer
{
    [TestFixture]
    public class TestFlyTransformer
    {
        private ITransformer _fakeTransformer;


        [Test]
        public void FlyTransformer_transform_flylist_correctly()
        {

            var testfly1 = new Fly();
            testfly1.date = DateTime.Now;
            testfly1.Tag = "test1";
            testfly1.xcor = 1;
            testfly1.ycor = 1;
            testfly1.zcor = 1;


            List<Fly> testflyList = new List<Fly>();
            testflyList.Add(testfly1);
            Assert


            /*
            for (int i = 0; i < testflyList.Count; i++)
            {
                testflyList[i] = TransformData(testflyList[i]);
            }*/
        }

    }
}
