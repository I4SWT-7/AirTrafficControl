using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    class TestListener
    {
        private IParser rec;
        TestListener(IParser reciever)
        {
            this.rec = reciever;
            this.rec.ParserDataReady += RecieveEvent;
        }

        private void RecieveEvent(object sender, RawParserDataEventArgs e)
        {
            foreach (var data in e.flylist)
            {
                Console.WriteLine("Event triggered");
            }
        }
    }
}
