using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverApplication
{
    public class CheckForSepCond
    {
        private CalculateDistance calcdistance = new CalculateDistance();
        private WriteLog logger = new WriteLog();
        public void SepCond(Fly prevfly, Fly Newfly)
        {
            int biggestzvalue;
            int smallestzvalue;
            if (prevfly.zcor > Newfly.zcor)
            {
                biggestzvalue = prevfly.zcor;
                smallestzvalue = Newfly.zcor;
            }
            else
            {
                biggestzvalue = Newfly.zcor;
                smallestzvalue = prevfly.zcor;
            }
            Console.WriteLine($"{biggestzvalue} {smallestzvalue}");
            if (prevfly.Tag != Newfly.Tag && (biggestzvalue - smallestzvalue) < 300)
            {
                if (prevfly.Tag != Newfly.Tag && calcdistance.CalcDistance(Newfly, prevfly) < 5000)
                {
                    logger.WriteLogWarning(prevfly, Newfly);
                }
            }
        }
    }
}
