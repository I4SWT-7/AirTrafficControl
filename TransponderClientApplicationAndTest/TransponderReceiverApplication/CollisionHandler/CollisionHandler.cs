//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TransponderReceiver;
//using TransponderReceiverApplication;

//namespace TransponderReceiverApplication
//{
//    public class CollisionHandler : ICollisionHandler
//    {
//        private List<Fly> data;
//        private ITransformer transformer;

//        public CollisionHandler(ITransformer receiver)
//        {
//            this.transformer = receiver;
//            this.transformer.TransformerDataReady += ReceiveData;
//        }
//        public void DataRecived()
//        {
//        }

//        public void ReceiveData(object sender, RawTransformerDataEventArgs e)
//        {
//            foreach(var data in e.FlyList)
//            {
//                Console.WriteLine($"CollisionFormat: {data.date}");
//            }
//        }
//    }
//}
