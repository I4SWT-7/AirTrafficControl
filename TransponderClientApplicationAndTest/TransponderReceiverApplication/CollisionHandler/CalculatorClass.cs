using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverApplication
{
    public class CalculatorClass
    {
        private List<Fly> WatchList;
        private double course;
        private int distance;
        private int speed;
        private int timeStamps;

        public event EventHandler<SepCondArgs> SepCond; 

        public int CalculateDistance(List<Fly> watchList)
        {
            //We need the x and y coordinates for two planes to calculate the distance
            distance = Math.Sqrt(Math.Pow(Fly.xcor1 - Fly.xcor2, 2) + Math.Pow(Fly.ycor1 - Fly.ycor2, 2));
            return distance;
        }

        public double CalculateCourse(List<Fly> watchlist)
        {
            //the X and Y values used below here do not represent the actual coordinates
            //see https://www.igismap.com/formula-to-find-bearing-or-heading-angle-between-two-points-latitude-longitude/ for more info!

            double x;
            double y;
            int delta_y;

            delta_y = Math.Abs(Fly.ycor1 - Fly.ycor2);

            x = Math.Cos(Fly.xcor2) * Math.Sin(delta_y);
            y = (Math.Cos(Fly.xcor1) * Math.Sin(Fly.xcor1)) -
                (Math.Sin(Fly.xcor1) * Math.Cos(Fly.xcor2) * Math.Cos(delta_y));

            course = Math.Atan2(x, y);
            // Convert from radians to degrees and return
            return course * (180.0 / Math.PI);
        }

        int CalculateSpeed(List<Fly> watchlist)
        {
            // To calculate the speed of an airplane we need two different timestamps from it
            timeStamps = Fly.date1 - Fly.date2;

            speed = distance / timeStamps;
            return speed;
        }

        int SeperationCondition(List<Fly> watchlist)
        {
            foreach(var Fly in FlyList)
            {
                foreach(var ObservedFly in FlyList)
                {
                    if(Fly.Tag != ObservedFly.Tag && (Fly.zcor - ObservedFly.zcor) < 300)
                    {
                        if(Fly.Tag != ObservedFly.Tag && CalculateDistance(Fly, ObservedFly) < 5000)
                        {
                            SepCondArgs args = new SepCondArgs();
                            SepCond(this, args);
                        }

                    }
                        
                }
            }
        }
    }
}
