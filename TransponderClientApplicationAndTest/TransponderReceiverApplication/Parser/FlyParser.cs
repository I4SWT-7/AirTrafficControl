using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;


namespace TransponderReceiverApplication
{
   public class FlyParser : IParser
    {
        private ITransponderReceiver receiver;
        public event EventHandler<RawParserDataEventArgs> ParserDataReady;

        public FlyParser(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += RecieveData;
        }


        public List<Fly> Parsedata(List<string> data)
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
                Console.WriteLine($"Parser: {newplane.date.ToString("D")}");

                FlyList.Add(newplane);
            }
            //foreach (var fly in FlyList)
            //{
            //    Console.WriteLine($"{fly.Tag} {fly.date}+ {fly.date.Millisecond}");
            //}
            return FlyList;
        }

        private void RecieveData(object sender, RawTransponderDataEventArgs e)
        {

            List<string> stringlist = new List<string>();
            foreach (var data in e.TransponderData)
            {
                stringlist.Add(data);
            }
            ParserDataReady?.Invoke(this, new RawParserDataEventArgs(Parsedata(stringlist)));
        }
    }
}
