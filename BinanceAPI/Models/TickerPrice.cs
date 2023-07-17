using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinanceAPI.Models
{
    public class TickerPrice
    {
        public string symbol { get; set; }
        public decimal priceChangePercent { get; set; }
        public decimal lastPrice { get; set; }
    }
}