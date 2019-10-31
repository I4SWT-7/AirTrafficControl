using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public interface ICollisionHandler
    {
        //void WriteLogWarning(Fly fly);
        void DataRecived();

        //void ReceiveData(List<Fly> data);
    }
}
