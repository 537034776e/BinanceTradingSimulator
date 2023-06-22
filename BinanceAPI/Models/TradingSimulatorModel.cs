using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinanceTradingSimulator.Models
{
    public class TradingSimulatorModel
    {
        public bool rispostaOrdine { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}