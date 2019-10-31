using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication.Calculator
{
    public class CalculateSpeed
    {
        private int distance;
        private int speed;
        private int timeStamps;
        public int CalcSpeed(List<Fly> watchlist)
        {
            // To calculate the speed of an airplane we need two different timestamps from it
            timeStamps = Fly.date1 - Fly.date2;

            speed = distance / timeStamps;
            return speed;
        }
    }
}
