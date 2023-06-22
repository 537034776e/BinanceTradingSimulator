# Binance Trading Simulator

This project show an example of implementation for a Binance Trading Simulation, including the basic method for operation in Binance platform, including reading data, making order and testing. The repository will be update periodically with new method and optimization.

## How to start

To make application working for operations, you simply need to set your Binance API key in _API>BinanceAPI.cs_ class, both for Testnet and leading account. Just search for _**apiKey**_ and **_secretKey_** variable and configure your API key.

## Methods

Actually, the project is under development, so you'll not find all fundamental operations for trading or visualization. Current version of the solution include this methods:

+ GetOrdersFromAPI: get the list of all orders made with the account
+ GetTransactionsFromAPI: get the list of all transaction for a specific account
+ PlaceOrderOnTestnet: make an order on the Binance Testnet to simulate a trading operation

## Architecture

Binance Trading Simulator is based on an MVC pattern, that implements Binance API through HTTP requests to communicate with the trading platform ad execute several operations. Written in C#, the application uses .NET Framework 4.8 and HTML/CSS (with Bootstrap integration) for the View structure.
