using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication.Filter
{
    public class RawFilterDataEventArgs : EventArgs
    {
        public List<Fly> FlyList { get; set; }

        public RawFilterDataEventArgs(List<Fly> flyList)
        {
            FlyList = flyList;
        }
    }
}
