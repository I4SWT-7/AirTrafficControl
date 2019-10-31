using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return distance;
        }
    }
}
