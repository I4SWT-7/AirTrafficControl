using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;
using TransponderReceiverApplication.Transformer;

namespace TransponderReceiverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the real transponder data receiver
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            IParser myparser = new FlyParser(receiver);
            TestListener listener = new TestListener(myparser);
            ITransformer myTransformer = new FlyTransformer(myparser);

            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }
}
