using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
   public class ConsoleDisplay
    {
        public string PrintPlane(Fly fly, double speed, double course)
        {
            //Tag(text string, 6 characters)
            // • Current position(x-y, both in meters)
            // • Current altitude(meters)
            // • Current horizontal velocity(m / s)
            // • Current compass course(0 - 359 degrees, clockwise, 0 degrees is north)
            string displaystring =
                $"Displaying plane with tag:{fly.Tag}, x position {fly.xcor} meters, y position {fly.ycor} meters, altitude: {fly.zcor} meters, velocity: {speed} m/s course: {course} degrees ";
            Console.WriteLine(displaystring);
            return displaystring;
        }

        public string PrintSeperationWarning(Fly fly1, Fly fly2)
        {
            string displaystring =
                $"SEPERATION WARNING BETWEEN:{fly1.Tag} AND {fly2.Tag} WITH TIMESTAMPS: {fly1.date.ToString()} AND {fly2.date.ToString()}";
            Console.WriteLine(displaystring);
            return displaystring;
        }
    }
}
