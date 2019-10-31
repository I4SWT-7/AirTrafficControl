using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverApplication.Filter
{
    public interface IFilter
    {
        List<Fly> Filterdata(List<Fly> data);
        event EventHandler<RawFilterDataEventArgs> FilterDataReady;
    }
}
