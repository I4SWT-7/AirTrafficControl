#region Assembly TransponderReceiver, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Mathias H. Jespersen\Desktop\Au\4. Semester\I4SWT\Assignment2\AirTrafficControl\TransponderClientApplicationAndTest\TransponderReceiver.dll
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransponderReceiverApplication
{
    public class RawParserDataEventArgs : EventArgs
    {
        public RawParserDataEventArgs(List<Fly> flylist) {
            Console.WriteLine(flylist);
        }
       public List<Fly> flylist;
         
    }
}
