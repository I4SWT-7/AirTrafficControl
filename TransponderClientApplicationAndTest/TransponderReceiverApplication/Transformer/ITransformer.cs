using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;
using TransponderReceiver;

namespace TransponderReceiverApplication
{
    public interface ITransformer
    {
        Fly TransformData(Fly transfly);
        event EventHandler<RawTransformerDataEventArgs> TransformerDataReady;
    }
}
