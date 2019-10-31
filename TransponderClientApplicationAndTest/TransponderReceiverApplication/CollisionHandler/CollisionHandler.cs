using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using TransponderReceiverApplication.Transformer;

namespace TransponderReceiverApplication
{
    public class CollisionHandler : ICollisionHandler
    {
        private List<Fly> data;
        private ITransformer transformer;

        public CollisionHandler(ITransformer receiver)
        {
            this.transformer = receiver;
            this.transformer.TransformerDataReady += ReceiveData;
        }
        public void DataRecived()
        {
            Console.WriteLine("Event triggered in Collisionhandler");
        }

        public void ReceiveData(object sender, RawTransformerDataEventArgs e)
        {
            DataRecived();
        }
    }
}
