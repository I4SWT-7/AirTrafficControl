using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    class Fly
    {
        string Tag;
        int xcor;
        int ycor;
        int zcor;
        DateTime date;

        Fly()
        {
            date = new DateTime();
            Tag = "Unknown";
            xcor = 0;
            ycor = 0;
            zcor = 0;
            date = DateTime.Now;
        }
    }
}
