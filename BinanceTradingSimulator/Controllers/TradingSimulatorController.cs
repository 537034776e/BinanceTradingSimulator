using BinanceAPI.Models;
using System.Web.Mvc;
using BinanceTradingSimulator.API;
using System.Collections.Generic;
using System;

namespace BinanceTradingSimulator.Controllers
{
    public class TradingSimulatorController : Controller
    {
        public TradingSimulatorModel model;
        private API.BinanceAPI binanceAPI = new API.BinanceAPI();

        // Dichiarazione del controller generico
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
            return View("PlaceTestnetOrder", model.rispostaOrdine);
        }

        // Azione che mostra l'ordine sulla Testnet Binance
        public ActionResult PlaceOrder()
        {
            model.rispostaOrdine = binanceAPI.PlaceOrder("BTCUSDT", 2, 20000, "SELL", "MARKET");
            return View("PlaceOrder", model.rispostaOrdine);
        }

        // Azione che mostra la risposta al ping verso le API Binance
        public ActionResult BinancePingAPI()
        {
            model.rispostaPing = binanceAPI.PingAPI();
            return View("BinancePingAPI", model.rispostaPing);
        }

        // Azione che mostra che mostra il ticker price 24hr del simbolo selezionato
        public ActionResult TickerPrice24hr()
        {
            model.TickerPriceList = binanceAPI.GetTickerPrice24hr("BTCUSDT");
            return View("TickerPrice24hr", model.TickerPriceList);
        }

        // Azione che mostra i valori di candela per il simbolo nell'intervallo
        public ActionResult KlinesValues()
        {
            model.Klines = binanceAPI.GetKlines("BTCUSDT","1h");
            return View("KlinesValues", model.Klines);
        }
    }
}
