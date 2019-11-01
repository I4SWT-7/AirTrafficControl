using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using TransponderReceiverApplication;


namespace TestFilter.Test.Unit
{
    [TestFixture]
    public class TestFilter
    {
        private ITransformer _fakeTransformer;
        private Filter _uut;
        private RawFilterDataEventArgs _TestFilterEventArg;

        private List<Fly> _testFlyList;
        private readonly Fly _noProblemFly1 = new Fly("NoProblemFly1", 10000, 10000, 500);
        private readonly Fly _noProblemFly2 = new Fly("NoProblemFly2", 10001, 10001, 501);
        private readonly Fly _noProblemFly3 = new Fly("NoProblemFly3", 90000, 90000, 20000);
        private readonly Fly _noProblemFly4 = new Fly("NoProblemFly4", 89999, 89999, 19999);
        private readonly Fly _nameProblemFly1 = new Fly("nameProblemFly", 45000, 45000, 10000);
        private readonly Fly _nameProblemFly2 = new Fly("nameProblemFly", 45000, 45000, 10000);
        private readonly Fly _xCoorHighProblemFly = new Fly("xCoorHighProblemFly", 90001, 10000, 500);
        private readonly Fly _xCoorLowProblemFly = new Fly("xCoorLowProblemFly", 9999, 10000, 500);
        private readonly Fly _yCoorHighProblemFly = new Fly("yCoorHighProblemFly", 10000, 90001, 500);
        private readonly Fly _yCoorLowProblemFly = new Fly("yCoorLowProblemFly", 10000, 9999, 500);
        private readonly Fly _zCoorHighProblemFly = new Fly("zCoorHighProblemFly", 10000, 10000, 20001);
        private readonly Fly _zCoorLowProblemFly = new Fly("zCoorLowProblemFly", 10000, 10000, 499);


        [SetUp]
        public void SetUp()
        {
            _fakeTransformer = Substitute.For<ITransformer>();
            _uut = new Filter(_fakeTransformer);

            _testFlyList = new List<Fly>() 
            {
                //_noProblemFly1, _noProblemFly2, _noProblemFly3, _noProblemFly4, 
                //_nameProblemFly1, _nameProblemFly2, _xCoorHighProblemFly,
                //_xCoorLowProblemFly, _yCoorHighProblemFly, _yCoorLowProblemFly,
                //_zCoorHighProblemFly, _zCoorLowProblemFly
            };
            _TestFilterEventArg = null;
            _uut.FilterDataReady += (o, arg) => { _TestFilterEventArg = arg; };
        }

        [Test]
        public void Event_Received_From_Transformer()
        {
            _testFlyList.Add(_noProblemFly1);
            _testFlyList.Add(_noProblemFly2);
            
            // Raise event in fake
            _fakeTransformer.TransformerDataReady += Raise.EventWith<RawTransformerDataEventArgs>(
                this,
                new RawTransformerDataEventArgs(_testFlyList) {  });

            // This asserts that uut has connected to the event
            // And handles value correctly
            Assert.That(_uut.FilterFlyList.Count == 2);
        }

        [Test]
        public void Event_Sent()
        {
            _uut.ReceiveData(this,new RawTransformerDataEventArgs(_testFlyList));
            Assert.That(_TestFilterEventArg, Is.Not.Null);
        }

        [Test]
        public void FilterData_No_Legal_Fly_Deleted()
        {
            _testFlyList.Add(_noProblemFly1);
            _testFlyList.Add(_noProblemFly2);
            _testFlyList.Add(_noProblemFly3);
            _testFlyList.Add(_noProblemFly4);
            Assert.That(_uut.FilterData(_testFlyList).Count == 4);
        }

        [Test]
        public void FilterData_Same_Name_Delete()
        {
            _testFlyList.Add(_noProblemFly1);
            _testFlyList.Add(_noProblemFly2);
            _testFlyList.Add(_noProblemFly3);
            _testFlyList.Add(_noProblemFly4);
            _testFlyList.Add(_nameProblemFly1);
            _testFlyList.Add(_nameProblemFly2);
            Assert.That(_uut.FilterData(_testFlyList).Count == 5);
        }

        [Test]
        public void FilterData_XCoorHigh_Delete()
        {
            _testFlyList.Add(_xCoorHighProblemFly);
            Assert.That(_uut.FilterData(_testFlyList).Count == 0);
        }

        [Test]
        public void FilterData_XCoorLow_Delete()
        {
            _testFlyList.Add(_xCoorLowProblemFly);
            Assert.That(_uut.FilterData(_testFlyList).Count == 0);
        }

        [Test]
        public void FilterData_YCoorHigh_Delete()
        {
            _testFlyList.Add(_yCoorHighProblemFly);
            Assert.That(_uut.FilterData(_testFlyList).Count == 0);
        }

        [Test]
        public void FilterData_YCoorLow_Delete()
        {
            _testFlyList.Add(_yCoorLowProblemFly);
            Assert.That(_uut.FilterData(_testFlyList).Count == 0);
        }

        [Test]
        public void FilterData_ZCoorHigh_Delete()
        {
            _testFlyList.Add(_zCoorHighProblemFly);
            Assert.That(_uut.FilterData(_testFlyList).Count == 0);
        }

        [Test]
        public void FilterData_ZCoorLow_Delete()
        {
            _testFlyList.Add(_zCoorLowProblemFly);
            Assert.That(_uut.FilterData(_testFlyList).Count == 0);
        }

    }
}

