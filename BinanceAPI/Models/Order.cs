using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinanceTradingSimulator.Models
{
    public class Order
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}