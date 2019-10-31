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

        public Fly(string tag = "Unkown", int x = 0, int y = 0, int z = 0)
        {
            date = new DateTime();
            Tag = tag;
            xcor = x;
            ycor = y;
            zcor = z;
            date = DateTime.Now;
        }
    }
}
