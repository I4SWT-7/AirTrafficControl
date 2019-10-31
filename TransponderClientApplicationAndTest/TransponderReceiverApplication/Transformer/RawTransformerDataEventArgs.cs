using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public class RawTransformerDataEventArgs : EventArgs
    {
        public List<Fly> FlyList { get; set; }

        public RawTransformerDataEventArgs(List<Fly> flyList)
        {
            FlyList = flyList;
        }
    }
}
