using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;


namespace TransponderReceiverApplication
{
    class FlyParser : IParser
    {
        List<Fly> FlyList = new List<Fly>();
        List<String> SavedData = new List<string>();
        private ITransponderReceiver receiver;

        public FlyParser(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += RecieveData;
        }

        public void Parsedata(string data)
        {
            // create new Fly object, insert data from parameter into fly object and save to fly list   
            Console.WriteLine($"FlyParserData {data}");
        }


        private void RecieveData(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var data in e.TransponderData)
            {
                Parsedata(data);
            }
        }
    }
}
