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
        private CalculatorClass calculator;
        private ITransformer transformer;

        public CollisionHandler(ITransformer receiver)
        {
            this.transformer = receiver;
            this.transformer.TransformerDataReady += ReceiveData;
        }

        public void WriteLogWarning(Fly fly)
        {
            string dir = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Lines er hvor vi skal gemme det data der skal logges
            string[] lines = { "test1.", "test2", "test3", "test4" };

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(dir + @"LogFile.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }
        }

        public void ReceiveData(object sender, RawTransformerDataEventArgs e)
        {
            
        }
    }
}
