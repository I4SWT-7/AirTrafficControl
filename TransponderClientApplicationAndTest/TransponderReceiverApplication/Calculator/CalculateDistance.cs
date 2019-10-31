using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace TransponderReceiverApplication.Calculator
{
    public class CalculateDistance
    {
        public float distance;
        private List<Fly> WatchList;
        public float CalcDistance(List<Fly> watchList)
        {
            //We need the x and y coordinates for two planes to calculate the distance
            distance = Math.Sqrt(Math.Pow(Fly.xcor1 - Fly.xcor2, 2) + Math.Pow(Fly.ycor1 - Fly.ycor2, 2));
=======
namespace TransponderReceiverApplication
{
    public class CalculateDistance
    {
        public double CalcDistance(Fly prevfly, Fly newfly)
        {
            //We need the x and y coordinates for two planes to calculate the distance
            double distance = Math.Sqrt(Math.Pow(prevfly.xcor - newfly.xcor, 2) + Math.Pow(prevfly.ycor - newfly.ycor, 2));
>>>>>>> eb2d032e840d903508b70b90366ea09854656e1a
            return distance;
        }
    }
}
