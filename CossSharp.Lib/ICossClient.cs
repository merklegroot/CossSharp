using CossSharp.Lib.Models;
using System.Collections.Generic;

namespace CossSharp.Lib
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

        string GetOrderBookRaw(string symbol, string baseSymbol);

        string GetBalanceRaw(CossApiKey apiKey);
        List<CossBalanceItem> GetBalance(CossApiKey apiKey);

        string GetOpenOrdersRaw(CossApiKey apiKey, string symbol, string baseSymbol);
        CossGetOpenOrdersResponseMessage GetOpenOrders(CossApiKey apiKey, string symbol, string baseSymbol);

        string CreateOrderRaw(CossApiKey apiKey, string symbol, string baseSymbol, decimal price, decimal quantity, bool isBid);
        CossCreateOrderResponseMessage CreateOrder(CossApiKey apiKey, string symbol, string baseSymbol, decimal price, decimal quantity, bool isBid);

        string CancelOrderRaw(CossApiKey apiKey, string nativeSymbol, string nativeBaseSymbol, string orderId);
        CossCancelOrderResponseMessage CancelOrder(CossApiKey apiKey, string nativeSymbol, string nativeBaseSymbol, string orderId);

        CossGetCompletedOrdersResponseMessage GetCompletedOrders(CossApiKey apiKey, string symbol, string baseSymbol, int? limit = null, int? page = null);
        string GetCompletedOrdersRaw(CossApiKey apiKey, string symbol, string baseSymbol, int? limit = null, int? page = null);

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
