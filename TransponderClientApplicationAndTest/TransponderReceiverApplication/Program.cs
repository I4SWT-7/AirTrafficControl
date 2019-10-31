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
            FlyParser myparser = new FlyParser(receiver);
            FlyTransformer transform = new FlyTransformer(myparser);
<<<<<<< HEAD
            Filter filter = new Filter(transform);
            CollisionHandler colhandler = new CollisionHandler(filter);
=======
            //CollisionHandler colhandler = new CollisionHandler(transform);
>>>>>>> 38e5c9ff3f46968fdb72535fff97f379d38793bc

            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }
}
