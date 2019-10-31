using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
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
=======
namespace TransponderReceiverApplication
{
    class CalculateSpeed
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
>>>>>>> eb2d032e840d903508b70b90366ea09854656e1a
            return speed;
        }
    }
}
