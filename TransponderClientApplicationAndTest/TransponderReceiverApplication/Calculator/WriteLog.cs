using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public class WriteLog
    {
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
    }
}
