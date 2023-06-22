﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using BinanceTradingSimulator.Models;

namespace BinanceTradingSimulator.API
{
    public class BinanceAPI
    {

        // Metodo per ottenere gli ordini dalle API di Binance
        public List<Order> GetOrdersFromAPI()
        {
            var orders = new List<Order>();

            using (var client = new HttpClient())
            {
                // Imposta l'endpoint e l'header dell'API di Binance
                var endpoint = "https://api.binance.com/api/v3/openOrders";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Imposta i parametri necessari per l'autenticazione
                var apiKey = "your-api-key";
                var secretKey = "your-secret-key";
                var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                var queryString = $"timestamp={timestamp}";
                var signature = CalculateSignature(queryString, secretKey);

                // Aggiungi l'autenticazione all'header
                client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);

                // Esegui la chiamata HTTP GET per ottenere gli ordini
                var response = client.GetAsync($"{endpoint}?{queryString}&signature={signature}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<Order>>(json);
                }
                else
                {
                    // Gestisci l'errore della chiamata API
                    Console.WriteLine($"Errore nella chiamata API: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }

            return orders;
        }

        // Metodo per ottenere le transazioni dalle API di Binance
        public List<Transaction> GetTransactionsFromAPI()
        {
            var transactions = new List<Transaction>();

            using (var client = new HttpClient())
            {
                // Imposta l'endpoint e l'header dell'API di Binance
                var endpoint = "https://api.binance.com/api/v3/myTrades";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Imposta i parametri necessari per l'autenticazione
                var apiKey = "your-api-key";
                var secretKey = "your-secret-key";
                var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                var queryString = $"timestamp={timestamp}";
                var signature = CalculateSignature(queryString, secretKey);

                // Aggiungi l'autenticazione all'header
                client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);

                // Esegui la chiamata HTTP GET per ottenere le transazioni
                var response = client.GetAsync($"{endpoint}?{queryString}&signature={signature}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    transactions = JsonConvert.DeserializeObject<List<Transaction>>(json);
                }
                else
                {
                    // Gestisci l'errore della chiamata API
                    Console.WriteLine($"Errore nella chiamata API: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }

            return transactions;
        }

        // Metodo per eseguire un ordine sulla Testnet di Binance
        public bool PlaceOrderOnTestnet(string symbol, decimal quantity, decimal price, string side, string type)
        {
            using (var client = new HttpClient())
            {
                // Imposta l'endpoint e l'header dell'API di Binance Testnet
                var endpoint = "https://testnet.binance.vision/api/v3/order/test";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Imposta i parametri dell'ordine
                var apiKey = "your-testnet-api-key";
                var secretKey = "your-testnet-secret-key";
                var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                var queryString = $"symbol={symbol}&side={side}&type={type}&quantity={quantity}&price={price}&timestamp={timestamp}";
                var signature = CalculateSignature(queryString, secretKey);

                // Aggiungi l'autenticazione all'header
                client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);

                // Esegui la chiamata HTTP POST per eseguire l'ordine
                var content = new StringContent($"symbol={symbol}&side={side}&type={type}&quantity={quantity}&price={price}&timestamp={timestamp}&signature={signature}", Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = client.PostAsync(endpoint, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<dynamic>(json);

                    // Verifica il risultato dell'ordine
                    if (result.status == "FILLED")
                    {
                        // L'ordine è stato eseguito con successo
                        return true;
                    }
                    else
                    {
                        // L'ordine non è stato eseguito correttamente
                        Console.WriteLine($"Errore nell'esecuzione dell'ordine: {result.msg}");
                        return false;
                    }
                }
                else
                {
                    // Gestisci l'errore della chiamata API
                    Console.WriteLine($"Errore nella chiamata API: {response.StatusCode} - {response.ReasonPhrase}");
                    return false;
                }
            }



        }
        // Metodo per calcolare la firma dell'autenticazione
        private string CalculateSignature(string queryString, string secretKey)
        {
            var hmacsha256 = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var signatureBytes = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(queryString));
            return BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();
        }
    }
    }