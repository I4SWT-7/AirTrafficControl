using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    class CalculateSpeed
    {
        private int distance;
        private double speed;
        private TimeSpan timeStamps;
        public double CalcSpeed(Fly prevfly, Fly newfly)
        {
            // To calculate the speed of an airplane we need two different timestamps from it
            timeStamps = (prevfly.date - newfly.date);
            speed = distance / timeStamps.TotalSeconds;
            return speed;
        }
    }
}
