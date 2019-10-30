using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication.CollisionHandler
{
    interface ICollisionHandler
    {
        void WriteLogWarning(Fly fly);

        void ReceiveData(List<Fly> data);
    }
}
