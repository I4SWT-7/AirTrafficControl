﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using TransponderReceiverApplication;

namespace TransponderReceiverApplication
{
    public class CollisionHandler : ICollisionHandler
    {
        public List<Fly> PreviousData = new List<Fly>();
        private IFilter Receiver;
        private ConsoleDisplay display = new ConsoleDisplay();
        private CalculateCourse coursecalculator = new CalculateCourse();
        private CalculateSpeed speedcalculator = new CalculateSpeed();
        private CalculateDistance distancecalculator = new CalculateDistance();
        private CheckForSepCond SeperationCalculator = new CheckForSepCond();
        public double speed = 0;
        public double course = 0;

        public CollisionHandler(IFilter receiver)
        {
            this.Receiver = receiver;
            this.Receiver.FilterDataReady += ReceiveData;
        }
        public void DataRecived(List<Fly> flylist)
        {

            if (PreviousData.Count == 0)
            {
                for (int i = 0; i < flylist.Count; i++)
                {
                    PreviousData.Add(flylist[i]);
                }
            }
            else
            {
                foreach(var prevfly in PreviousData)
                {
                    foreach(var newplane in flylist)
                    {
                        if(prevfly.Tag == newplane.Tag)
                        {
                            course = coursecalculator.CalcCourse(prevfly, newplane);
                            speed = speedcalculator.CalcSpeed(prevfly, newplane);
                            display.PrintPlane(prevfly, speed, course);
                        }
                        distancecalculator.CalcDistance(prevfly, newplane);
                        SeperationCalculator.SepCond(prevfly, newplane);

                    }
                }
                PreviousData.Clear();
                for (int i = 0; i < flylist.Count; i++)
                {
                    PreviousData.Add(flylist[i]);

                }
            }
        }

        public void ReceiveData(object sender, RawFilterDataEventArgs e)
        {
            //Console.WriteLine("CollisionHandler");
            foreach (var data in e.FlyList)
            {
                //Console.WriteLine($"{data.Tag} {data.xcor} {data.ycor} {data.zcor} {data.date}");
            }
            DataRecived(e.FlyList);
        }
    }
}
