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
        List<Fly> FlyListing = new List<Fly>();
        private IParser receiver;

        public FlyTransformer(IParser receiver)
        {
            this.receiver = receiver;

            this.receiver.ParserDataReady += ReceiveData;

        }


        public void TransformData(List<Fly> data)
        {
            
            foreach (var fly in FlyListing)
            {
                DateTime dt = fly.date;
                string stringDate = dt.ToString("MMM dd yyyy HH:mm:ss 'and' fff 'milliseconds'");

                DateTime newDt = DateTime.ParseExact(stringDate, "MMM dd yyyy HH:mm:ss 'and' fff 'milliseconds'", null);
            }

        }

        private void ReceiveData(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var data in e.ParserData)
            {
                TransformData(FlyListing);
            }
        }

    }
}
