using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverApplication.Transformer
{
    class FlyTransformer : ITransformer
    {
        //List<Fly> FlyListing = new List<Fly>();
        private IParser receiver;
        public event EventHandler<RawTransformerDataEventArgs> TransformerDataReady;

        public FlyTransformer(IParser receiver)
        {
            this.receiver = receiver;

            this.receiver.ParserDataReady += ReceiveData;

        }


        public Fly TransformData(Fly transfly)
        {
            DateTime dt = transfly.date;
            string stringDate = dt.ToString("MMM dd yyyy HH:mm:ss 'and' fff 'milliseconds'");
            DateTime newDt = DateTime.ParseExact(stringDate, "MMM dd yyyy HH:mm:ss 'and' fff 'milliseconds'", null);
            transfly.date = newDt;
            return transfly;
        }

        private void ReceiveData(object sender, RawParserDataEventArgs e)
        {
            //foreach (var fly in e.Flylist)
            //{
            //    FlyListing.Add(TransformData(fly));
            //}

            for (int i = 0; i < e.Flylist.Count; i++)
            {
                e.Flylist[i] = TransformData(e.Flylist[i]);
            }
            TransformerDataReady.Invoke(this, new RawTransformerDataEventArgs(e.Flylist));
        }

    }
}
