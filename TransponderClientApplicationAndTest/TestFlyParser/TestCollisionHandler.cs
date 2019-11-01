using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using TransponderReceiverApplication;

namespace TestCollisionHandler.Test.Unit
{
    [TestFixture]
    public class TestCollisionHandler
    {
        private IFilter _fakeFilter;
        private CollisionHandler _uut;

        private Fly _fly1;
        private Fly _fly2;
        private Fly _fly3;
        private Fly _fly4;
        private Fly _fly5;
        private Fly _fly6;

        private DateTime _date1;
        private DateTime _date2;

        private List<Fly> _testFlyList;

        [SetUp]
        public void SetUp()
        {
            _fakeFilter = Substitute.For<IFilter>();
            _uut = new CollisionHandler(_fakeFilter);
            _testFlyList = new List<Fly>();

        _fly1 = new Fly("Fly1", 10000, 10000, 500);
        _fly2 = new Fly("Fly2", 10100, 10000, 500);
        _fly3 = new Fly("Fly3", 10000, 10000, 500);
        _fly4 = new Fly("Fly4", 10000, 10000, 500);
        _fly5 = new Fly("Fly5", 10000, 10000, 500);
        _fly6 = new Fly("Fly6", 10000, 10000, 500);

        //_date1 = new DateTime();
        //_date2 = new DateTime();
        _date1 = DateTime.Now;
        _date2 = _date1;
        _date2 = _date2.AddSeconds(1);
        }

        [Test]
        public void Event_Received_From_Filter()
        {
            _testFlyList.Add(_fly1);
            // Raise event in fake
            _fakeFilter.FilterDataReady += Raise.EventWith<RawFilterDataEventArgs>(
                this,
                new RawFilterDataEventArgs(_testFlyList) { });

            // This asserts that uut has connected to the event
            // And handles value correctly
            Assert.That(_uut.PreviousData == _testFlyList);
        }

        [Test]
        public void DataReceived_Same_NameTag()
        {
            _fly1.Tag = "SameName";
            _fly2.Tag = "SameName";
            _fly1.date = _date1;
            _fly2.date = _date2;

            _testFlyList.Add(_fly1);
            _uut.DataRecived(_testFlyList);

            _testFlyList.Clear();
            _testFlyList.Add(_fly2);
            _uut.DataRecived(_testFlyList);

            Assert.That(_uut.speed == 100);
        }


    }
}