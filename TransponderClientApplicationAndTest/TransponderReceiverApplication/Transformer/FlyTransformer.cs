using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverApplication.Transformer
{
    class FlyTransformer : ITransformer
    {
        List<Fly> data = new List<Fly>();
        private IParser receiver;

        public FlyTransformer(IParser receiver)
        {
            this.receiver = receiver;

            this.receiver.ParserDataReady += ReceiveData;

        }


        public void TransformData(List<Fly> data)
        {
            foreach (var Fly in data)
            {
                string datetime = Fly.Datetime.Now.ToString();
                string createDate = Convert.ToDateTime(datetime).ToString("F");
                DateTime dt = DateTime.ParseExact(createDate, "yyyy-MM-dd hh:mm: tt", CultureInfo.InvariantCulture)

            }
            
        }

        private void ReceiveData(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var data in e.ParserData)
            {
                TransformData(data);
            }
        }

    }
}
