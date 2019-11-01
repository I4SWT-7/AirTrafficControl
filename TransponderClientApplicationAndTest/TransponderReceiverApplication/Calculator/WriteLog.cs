using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public class WriteLog
    {
       public void WriteLogWarning(Fly prevfly, Fly newfly)
       {
            List<string> taglist = new List<string>();
            string dir = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
                // If the two tags does not exists in the taglist = We may print a warning and save the tags in the taglist
            if (!(taglist.Contains(prevfly.Tag) && taglist.Contains(newfly.Tag)))
            {
                string[] lines = { $"WARNING, RISK OF COLLISION BETWEEN: {prevfly.Tag} AND {newfly.Tag} RESGIERED AT : {prevfly.date.ToString()} {newfly.date.ToString()} " +
                        $"DEBUG: Prefly x,y,z{prevfly.xcor} {prevfly.ycor} {prevfly.zcor} Newfly x,y,z {newfly.xcor} {newfly.ycor} {newfly.zcor}" };
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"AirTrafficLogfile.txt"))
                {
                    foreach (string line in lines)
                    {
                        file.WriteLine(line);
                        taglist.Add(prevfly.Tag);
                        taglist.Add(newfly.Tag);
                    }
                }
            }
        }
    }
}
