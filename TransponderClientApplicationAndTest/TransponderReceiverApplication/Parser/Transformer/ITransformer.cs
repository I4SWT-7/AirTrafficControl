using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication.Transformer
{
    interface ITransformer
    {
        void TransformData(List<Fly> data);
    }
}
