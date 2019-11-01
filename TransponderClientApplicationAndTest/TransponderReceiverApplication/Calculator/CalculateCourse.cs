using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{

    public class CalculateCourse
    {
        
        public double CalcCourse(Fly previous, Fly newplane)
        {
            double courseInRadians = Math.Atan2(newplane.xcor - previous.xcor, newplane.ycor - previous.ycor);
            double degrees = 180 / Math.PI * courseInRadians;
            if (degrees < 0)
            {
                degrees = degrees + 360;
            }

            return degrees;
        }
    }
}
