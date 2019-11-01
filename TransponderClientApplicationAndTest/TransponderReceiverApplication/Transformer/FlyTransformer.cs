using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Threading;

namespace TransponderReceiverApplication
{
    public class FlyTransformer : ITransformer
    {
        public List<Fly> TransFlyList = new List<Fly>();
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
            string stringDate = dt.ToString(format:"yyyyMMddHHmmssfff");
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd. MMM yyyy HH:mm:ss:fff";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            DateTime newDt = DateTime.ParseExact(stringDate, "yyyyMMddHHmmssfff", culture);
            transfly.date = newDt;
            return transfly;    
        }
        public void ReceiveData(object sender, RawParserDataEventArgs e)
        {
            //Console.WriteLine("Transformer");
            for (int i = 0; i < e.Flylist.Count; i++)
            {
                e.Flylist[i] = TransformData(e.Flylist[i]);
                TransFlyList[i] = e.Flylist[i];
            }
            Console.WriteLine(TransFlyList[0].Tag);
            //TransFlyList = e.Flylist;
            TransformerDataReady?.Invoke(this, new RawTransformerDataEventArgs(e.Flylist));
        }

    }
}

