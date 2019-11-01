using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
   public class ConsoleDisplay
    {
        public void PrintPlane(Fly fly, double speed, double course)
        {
               //Tag(text string, 6 characters)
               // • Current position(x-y, both in meters)
               // • Current altitude(meters)
               // • Current horizontal velocity(m / s)
               // • Current compass course(0 - 359 degrees, clockwise, 0 degrees is north)
               Console.WriteLine($"Displaying plane with tag:{fly.Tag}, x position {fly.xcor}meters, y position {fly.ycor} meters, altitude: {fly.zcor}, velocity: {speed} course: {course} degrees ");
        }
    }
}
