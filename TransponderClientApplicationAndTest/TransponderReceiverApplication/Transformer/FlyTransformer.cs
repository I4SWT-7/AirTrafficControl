﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Threading;

namespace TransponderReceiverApplication
{
    public class FlyTransformer : ITransformer
    {
        public List<Fly> TransFlyList = new List<Fly>();
        public List<Fly> SavedFlyTest = new List<Fly>();
        private IParser receiver;
        public event EventHandler<RawTransformerDataEventArgs> TransformerDataReady;
        public FlyTransformer(IParser receiver)
        {
            this.receiver = receiver;
            this.receiver.ParserDataReady += ReceiveData;
        }
        public Fly TransformData(Fly transfly)
        {
            DateTime dt = transfly.date;
            string stringDate = dt.ToString(format:"yyyyMMddHHmmssfff");
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd. MMM yyyy HH:mm:ss:fff";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            DateTime newDt = DateTime.ParseExact(stringDate, "yyyyMMddHHmmssfff", culture);
            transfly.date = newDt;
            return transfly;    
        }
        public void ReceiveData(object sender, RawParserDataEventArgs e)
        {
            TransFlyList.Clear();
            for (int i = 0; i < e.Flylist.Count; i++)
            {
                TransFlyList.Add(TransformData(e.Flylist[i]));
            }

            TransformerDataReady?.Invoke(this, new RawTransformerDataEventArgs(TransFlyList));
        }

    }
}



