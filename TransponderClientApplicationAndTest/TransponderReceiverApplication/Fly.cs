using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public class Fly
    {
        public string Tag;
        public int xcor;
        public int ycor;
        public int zcor;
        public DateTime date;

        public Fly()
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
