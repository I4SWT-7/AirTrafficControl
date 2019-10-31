//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TransponderReceiverApplication.Calculator
//{
//    class CheckForSepCond
//    {
//        private List<Fly> WatchList;
//        public event EventHandler<SepCondArgs> SepCond;
//        int SepCond(List<Fly> watchlist)
//        {
//            foreach (var Fly in FlyList)
//            {
//                foreach (var ObservedFly in FlyList)
//                {
//                    if (Fly.Tag != ObservedFly.Tag && (Fly.zcor - ObservedFly.zcor) < 300)
//                    {
//                        if (Fly.Tag != ObservedFly.Tag && CalculateDistance(Fly, ObservedFly) < 5000)
//                        {
//                            SepCondArgs args = new SepCondArgs();
//                            SepCond(this, args);
//                        }

//                    }

//                }
//            }
//        }
//    }
//}
