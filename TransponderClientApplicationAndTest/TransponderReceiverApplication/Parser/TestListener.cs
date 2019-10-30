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
        public TestListener(IParser reciever)
        {
            this.rec = reciever;
            this.rec.ParserDataReady += RecieveEvent;
        }

        private void RecieveEvent(object sender, RawParserDataEventArgs e)
        {
           Console.WriteLine("Event triggered");
            foreach (var data in e.Flylist)
            {
                Console.WriteLine(data.Tag, data.date);
            }
        }
    }
}
