using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication.Filter
{
    class Filter : IFilter
    {
        event EventHandler<RawFilterDataEventArgs> IFilter.FilterDataReady
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void IFilter.Filterdata(List<Fly> data)
        {
            throw new NotImplementedException();
        }
    }
}
