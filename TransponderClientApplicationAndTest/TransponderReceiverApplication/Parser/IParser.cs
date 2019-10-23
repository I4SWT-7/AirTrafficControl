using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    interface IParser
    {

        void Parsedata(string data);
        //unkown event sender / handler has to be added to send data to transformer
    }

}
