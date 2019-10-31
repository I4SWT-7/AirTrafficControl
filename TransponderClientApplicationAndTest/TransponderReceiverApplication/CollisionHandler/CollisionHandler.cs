using System;
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
        private List<Fly> PreviousData;
        private IFilter Receiver;
        private CalculateCourse coursecalculator = new CalculateCourse();
        private CalculateSpeed speedcalculator = new CalculateSpeed();

        public CollisionHandler(IFilter receiver)
        {
            this.Receiver = receiver;
            this.Receiver.FilterDataReady += ReceiveData;
        }
        public void DataRecived(List<Fly> flylist)
        {
            if (PreviousData == null)
            {
                PreviousData = flylist;
            }
            else
            {
                foreach(var prevfly in PreviousData)
                {
                    foreach(var newplane in flylist)
                    {
                        if(prevfly.Tag == newplane.Tag)
                        {
                            coursecalculator.CalcCourse(prevfly, newplane);
                            speedcalculator.CalcSpeed(prevfly, newplane);
                            
                        }
                    }
                }

                PreviousData = null;
                PreviousData = flylist;
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
