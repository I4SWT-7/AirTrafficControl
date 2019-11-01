﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{

    class CalculateCourse
    {
        private double course;
        public double CalcCourse(Fly previous, Fly newplane)
        {
            //the X and Y values used below here do not represent the actual coordinates
            //see https://www.igismap.com/formula-to-find-bearing-or-heading-angle-between-two-points-latitude-longitude/ for more info!
            double x;
            double y;
            int delta_y;

            delta_y = Math.Abs(previous.ycor - newplane.ycor);
            x = Math.Cos(newplane.xcor) * Math.Sin(delta_y);
            y = (Math.Cos(previous.xcor) * Math.Sin(previous.xcor)) -
                (Math.Sin(previous.xcor) * Math.Cos(newplane.xcor) * Math.Cos(delta_y));
            course = Math.Atan2(x, y);
            // Convert from radians to degrees and return
            return course * (180.0 / Math.PI); 

        }
    }
}
