using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverApplication;

namespace SeperationCondition.Test.Unit
{
    [TestFixture]
    public class SeperationConditionTest
    {
        Fly Fly1 = new Fly("TAG1", 1, 1, 500);
        Fly Fly2 = new Fly("TAG2", 9000, 9000, 500);
        Fly Fly3 = new Fly("TAG3", 1, 1, 500);
        Fly Fly4 = new Fly("TAG4", 5, 5, 500);
        Fly Fly5 = new Fly("TAG5", 1, 1, 1000);
        Fly Fly6 = new Fly("TAG6", 5, 5, 500);
        Fly Fly7 = new Fly("TAG7", 1, 1, 1000);
        Fly Fly8 = new Fly("TAG8", 9000, 9000, 500);
        [Test]
        public void SeperationCond_SameAlt_Faraway_ReturnResult()
        {
            //Arrange
            var uut = new CheckForSepCond();
            bool status = false;
            status = uut.SepCond(Fly1, Fly2);
            //Act & Assert
            Assert.IsFalse(status);
        }
        [Test]
        public void SeperationCond_SameAlt_Close_ReturnResult()
        {
            //Arrange
            var uut = new CheckForSepCond();
            bool status = false;
            status = uut.SepCond(Fly3, Fly4);
            //Act & Assert
            Assert.IsTrue(status);
        }
        [Test]
        public void SeperationCond_NoAltWarning_Close_ReturnResult()
        {
            //Arrange
            var uut = new CheckForSepCond();
            bool status = false;
            status = uut.SepCond(Fly5, Fly6);
            //Act & Assert
            Assert.IsFalse(status);
        }
        [Test]
        public void SeperationCond_NoAltWarning_NotClose_ReturnResult()
        {
            //Arrange
            var uut = new CheckForSepCond();
            bool status = false;
            status = uut.SepCond(Fly7, Fly8);
            //Act & Assert
            Assert.IsFalse(status);
        }
    }
}
