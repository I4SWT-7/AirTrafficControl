using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;


namespace TransponderReceiverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Using the real transponder data receiver
            //var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            //FlyParser myparser = new FlyParser(receiver);
            //FlyTransformer transform = new FlyTransformer(myparser);
            //Filter filter = new Filter(transform);
            //CollisionHandler colhandler = new CollisionHandler(filter);

            //// Let the real TDR execute in the background
            //while (true)
            //    Thread.Sleep(1000);

            Fly Fly1 = new Fly("TAG123", 1, 1, 500);
            Fly Fly2 = new Fly("TAG321", 2, 2, 600);
            Fly1.date = DateTime.ParseExact("20191006233456789", "yyyyMMddHHmmssfff", null);
            Fly2.date = DateTime.ParseExact("20191006213456789", "yyyyMMddHHmmssfff", null);

            WriteLog loggwriter = new WriteLog();

            loggwriter.WriteLogWarning(Fly1, Fly2);


        }
    }
}
