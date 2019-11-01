using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public class CalculateSpeed
    {
        private double distance;
        private double speed;
        private TimeSpan timeStamps;
        private CalculateDistance distancecalc = new CalculateDistance();
        public double CalcSpeed(Fly prevfly, Fly newfly)
        {
            // To calculate the speed of an airplane we need two different timestamps from it
            timeStamps = (prevfly.date - newfly.date);
            distance = distancecalc.CalcDistance(prevfly, newfly);
            speed = distance / timeStamps.TotalSeconds;
           ;
            return Math.Round(speed, 2);
        }
    }
}
