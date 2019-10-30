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
            // Using the real transponder data receiver
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            // var parserreceiver = ???
            // Dependency injection with the real TDR
            FlyParser myparser = new FlyParser(receiver);
            //TestListener listener = new TestListener();CreateTransponderDataReceiver


            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }
}
