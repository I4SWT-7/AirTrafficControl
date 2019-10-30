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
        List<String> SavedData = new List<string>();
        private ITransponderReceiver receiver;
        public event EventHandler<RawParserDataEventArgs> ParserDataReady;

        public FlyParser(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += RecieveData;
        }


        public void Parsedata(List<string> data)
        {
            List<Fly> FlyList = new List<Fly>();
            foreach (var list in data)
            {
                Fly newplane = new Fly();
                var splitted_data = list.Split(';');
                newplane.Tag = splitted_data[0];
                newplane.xcor = Int32.Parse(splitted_data[1]);
                newplane.ycor = Int32.Parse(splitted_data[2]);
                newplane.zcor = Int32.Parse(splitted_data[3]);
                newplane.date = DateTime.ParseExact(splitted_data[4], "yyyyMMddHHmmssfff", null);

                FlyList.Add(newplane);
            }
            //foreach (var fly in FlyList)
            //{
            //    Console.WriteLine($"{fly.Tag} {fly.date}+ {fly.date.Millisecond}");
            //}
            ParserDataReady?.Invoke(this, new RawParserDataEventArgs(FlyList));
        }

        private void RecieveData(object sender, RawTransponderDataEventArgs e)
        {

            List<string> stringlist = new List<string>();
            foreach (var data in e.TransponderData)
            {
                stringlist.Add(data);
            }
            Parsedata(stringlist);
        }
    }
}
