using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverApplication
{
    public class Filter : IFilter
    {
        private ITransformer receiver;
        public List<Fly> FilterFlyList = new List<Fly>();
        public event EventHandler<RawFilterDataEventArgs> FilterDataReady;

        public Filter(ITransformer receiver)
        {
            this.receiver = receiver;

            this.receiver.TransformerDataReady += ReceiveData;
        }

        public void ReceiveData(object sender, RawTransformerDataEventArgs e)
        {
            FilterData(e.TransFlyList); 
            
            FilterDataReady?.Invoke(this, new RawFilterDataEventArgs(FilterFlyList));
        }

        public List<Fly> FilterData(List<Fly> data)
        {
            FilterFlyList.Clear();
            int count = data.Count;
            for (int i = 0; i < count; i++)
            {
                string nameTag = data[i].Tag;
                int tagCount = 0;
                int x = data[i].xcor;
                int y = data[i].ycor;
                int z = data[i].zcor;
                for (int k = 0; k < data.Count; k++)
                {
                    if (data[k].Tag == nameTag)
                    {
                        tagCount++;
                    }
                }
                if (tagCount > 1 || 10000 > x || x > 90000 || 10000 > y || y > 90000 || 500 > z || z > 20000)
                {
                    data.RemoveAt(i);
                    count--;
                    i--;
                }
                else
                {
                    FilterFlyList.Add(data[i]);
                }
               
            }
            return FilterFlyList;
        }
    }
}
