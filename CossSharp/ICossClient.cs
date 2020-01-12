using CossSharp.Models;
using System.Collections.Generic;

namespace CossSharp
{
    public interface ICossClient
    {
        string GetExchangeInfoRaw();

        /// <summary>
        /// Calls an endpoint used by the website to get public info about coins.
        /// The results contain some details not yet exposed by the api.
        /// </summary>
        /// <returns>The response text</returns>
        string GetWebCoinsRaw();

        /// <summary>
        /// Calls an endpoint used by the website to get public info about coins.
        /// The results contain some details not yet exposed by the api.
        /// </summary>
        /// <returns>A deserialized list of coin information.</returns>
        List<CossWebCoin> GetWebCoins();

        string GetMarketSummariesRaw();
        CossGetMarketSummariesResponse GetMarketSummaries();

        string GetOrderBookRaw(string baseSymbol, string quoteSymbol);

        CossOrderBook GetOrderBook(string baseSymbol, string quoteSymbol);

        string GetBalanceRaw(CossApiKey apiKey);
        List<CossBalanceItem> GetBalance(CossApiKey apiKey);

        string GetOpenOrdersRaw(CossApiKey apiKey, string baseSymbol, string quoteSymbol);
        CossGetOpenOrdersResponseMessage GetOpenOrders(CossApiKey apiKey, string baseSymbol, string quoteSymbol);

        string CreateOrderRaw(CossApiKey apiKey, string baseSymbol, string quoteSymbol, decimal price, decimal quantity, bool isBid);
        CossCreateOrderResponseMessage CreateOrder(CossApiKey apiKey, string symbol, string quoteSymbol, decimal price, decimal quantity, bool isBid);

        string CancelOrderRaw(CossApiKey apiKey, string baseSymbol, string quoteSymbol, string orderId);
        CossCancelOrderResponseMessage CancelOrder(CossApiKey apiKey, string baseSymbol, string quoteSymbol, string orderId);

        CossGetCompletedOrdersResponseMessage GetCompletedOrders(CossApiKey apiKey, string baseSymbol, string quoteSymbol, int? limit = null, int? page = null);
        string GetCompletedOrdersRaw(CossApiKey apiKey, string baseSymbol, string quoteSymbol, int? limit = null, int? page = null);

        string GetAccountDetailsRaw(CossApiKey apiKey);
        CossAccountDetails GetAccountDetails(CossApiKey apiKey);

        string GetServerTimeRaw();
        long GetServerTime();

        /// <summary>
        /// Makes adjustments to the nonce based on the difference between the client's time and the server's time.
        /// </summary>
        void SynchronizeTime();
    }
}
