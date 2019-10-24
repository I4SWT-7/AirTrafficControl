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

            this.receiver.Parsedata(); += ReceiveData;

        }


        public void TransformData(List<Fly> data)
        {
            
        }

        private void ReceiveData(object sender, RawTransponderDataEventArgs e)
        {

        }

    }
}
