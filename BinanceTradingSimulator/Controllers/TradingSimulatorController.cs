using BinanceTradingSimulator.Models;
using System.Web.Mvc;
using BinanceTradingSimulator.API;
using System.Collections.Generic;
using System;

namespace BinanceTradingSimulator.Controllers
{
    public class TradingSimulatorController : Controller
    {
        public TradingSimulatorModel model;
        private BinanceAPI binanceAPI = new BinanceAPI();

        public TradingSimulatorController()
        {
            model = new TradingSimulatorModel();
        }

        // Azione che mostra l'elenco degli ordini
        public ActionResult ShowOrders()
        {
            // Recupera gli ordini dal modello (o dalle API di Binance)
            model.Orders = binanceAPI.GetOrdersFromAPI();
            return View("OrdersView", model.Orders);
        }

        // Azione che mostra l'elenco delle transazioni
        public ActionResult ShowTransactions()
        {
            // Recupera le transazioni dal modello (o dalle API di Binance)
            model.Transactions = binanceAPI.GetTransactionsFromAPI();
            return View("TransactionsView", model.Transactions);
        }

        // Azione che mostra l'ordine sulla Testnet Binance
        public ActionResult PlaceTestnetOrder()
        {
            model.rispostaOrdine=binanceAPI.PlaceOrderOnTestnet("BTCUSDT", 2,20000,"SELL","MARKET");
            return View("TestnetOrderView", model.rispostaOrdine);
        }

    }
}
