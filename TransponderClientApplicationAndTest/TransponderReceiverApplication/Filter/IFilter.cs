using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication.Filter
{
    public interface IFilter
    {
        void Filterdata(List<Fly> data);
        event EventHandler<RawFilterDataEventArgs> FilterDataReady;
    }
}
