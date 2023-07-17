using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinanceAPI.Models
{
    public class Klines
    {
        public int openTime { get; set; }
        public decimal openPrice { get; set; }
        public decimal highPrice { get; set; }
        public decimal lowPrice { get; set; }
        public decimal closePrice { get; set; }
        public decimal volume { get; set; }
        public int kCloseTime { get; set; }
        public decimal qVolume { get; set; }
        public int trades { get; set; }
        public decimal tbbVolume { get; set; }
        public decimal tbqVolume { get; set; }
        public string ignore { get; set; }

    }
}