using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication.CollisionHandler
{
    class CollisionHandler : ICollisionHandler
    {
        private List<Fly> data;
        private CalculatorClass calculator;
        private ITransformer transformer;

        public CollisionHandler(iTransformerReceiver receiver)
        {
            this.transformer = receiver;
            this.receiver.TransformerDataReady += ReceiveData()
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

        public void ReceiveData(object sender, )
        {
            
        }
    }
}
