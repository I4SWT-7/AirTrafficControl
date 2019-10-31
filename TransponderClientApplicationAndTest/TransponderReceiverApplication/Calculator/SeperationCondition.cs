using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace TransponderReceiverApplication.Calculator
{
    public class CheckForSepCond
    {
        private List<Fly> WatchList;
        public event EventHandler<SepCondArgs> SepCond;
        public int SeparationCond(List<Fly> watchlist)
        {
            foreach (var Fly in FlyList)
            {
                foreach (var ObservedFly in FlyList)
                {
                    if (Fly.Tag != ObservedFly.Tag && (Fly.zcor - ObservedFly.zcor) < 300)
                    {
                        if (Fly.Tag != ObservedFly.Tag && CalculateDistance(Fly, ObservedFly) < 5000)
                        {
                            SepCondArgs args = new SepCondArgs();
                            SepCond(this, args);
                        }

                    }

=======
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
>>>>>>> eb2d032e840d903508b70b90366ea09854656e1a
                }
            }
        }
    }
}
