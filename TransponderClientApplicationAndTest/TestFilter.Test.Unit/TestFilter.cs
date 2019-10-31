using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiverApplication;

namespace TestFilter.Test.Unit
{
    [TestFixture]
    public class TestFilter
    {
        private List<Fly> testFlyList;
        private int numberOfEvents;
        private Fly noProblemFly1;
        private Fly noProblemFly2;
        private Fly noProblemFly3;
        private Fly noProblemFly4;
        private Fly noProblemFly5;
        private Fly nameProblemFly1;
        private Fly nameProblemFly2;
        private Fly xCoorHighProblemFly;
        private Fly xCoorLowProblemFly;
        private Fly yCoorHighProblemFly;
        private Fly yCoorLowProblemFly;
        private Fly zCoorHighProblemFly;
        private Fly zCoorLowProblemFly;


        [SetUp]
        public void setUp()
        {

            testFlyList = new List<Fly>() {};
        }
    }
}
