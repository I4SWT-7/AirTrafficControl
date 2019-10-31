using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public class CalculateDistance
    {
        public double CalcDistance(Fly prevfly, Fly newfly)
        {
            //We need the x and y coordinates for two planes to calculate the distance
            double distance = Math.Sqrt(Math.Pow(prevfly.xcor - newfly.xcor, 2) + Math.Pow(prevfly.ycor - newfly.ycor, 2));
            return distance;
        }
    }
}
