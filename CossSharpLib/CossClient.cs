using CossSharpLib.Http;
using CossSharpLib.Models;
using CossSharpLib.Signator;
using CossSharpLib.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CossSharpLib
{
    // https://api.coss.io/v1/spec
    public class CossClient : ICossClient
    {
        private const int DefaultReceiveWindow = 10000;

        private const string ExchangeRoot = "https://exchange.coss.io/api/";
        private const string EngineRoot = "https://engine.coss.io/api/v1/";
        private const string TradeRoot = "https://trade.coss.io/c/api/v1/";
        private const string WebRoute = "https://coss.io/c/";

        private readonly ICossSignator _signator;
        private readonly IDateTimeUtil _dateTimeUtil;
        private readonly IHttpWebClient _httpWebClient;

        public CossClient() : this(new CossSignator(), new DateTimeUtil(), new HttpWebClient()) { }

        public CossClient(ICossSignator signator, IDateTimeUtil dateTimeUtil, IHttpWebClient httpWebClient)
        {
            _signator = signator;
            _dateTimeUtil = dateTimeUtil;
            _httpWebClient = httpWebClient;
        }

        public string GetExchangeInfoRaw()
        {
            const string Path = "exchange-info";
            var url = $"{TradeRoot}{Path}";
            return _httpWebClient.GetSync(url);
        }

        public CossExchangeInfo GetExchangeInfo() => GetAndDeserialize<CossExchangeInfo>(GetExchangeInfoRaw);

        public string GetWebCoinsRaw()
        {            
            var url = $"{WebRoute}coins/getinfo/all";
            return _httpWebClient.GetSync(url);
        }

        public List<CossWebCoin> GetWebCoins() => GetAndDeserialize<List<CossWebCoin>>(GetWebCoinsRaw);

        public string GetMarketSummariesRaw()
        {
            var url = $"{ExchangeRoot}getmarketsummaries";
            return _httpWebClient.GetSync(url);
        }

        public CossGetMarketSummariesResponse GetMarketSummaries() => GetAndDeserialize<CossGetMarketSummariesResponse>(GetMarketSummariesRaw);

        public string GetOrderBookRaw(string symbol, string baseSymbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) { throw new ArgumentNullException(nameof(symbol)); }
            if (string.IsNullOrWhiteSpace(baseSymbol)) { throw new ArgumentNullException(nameof(baseSymbol)); }

            var tradingPairText = GetTradingPairSymbol(symbol, baseSymbol);
            var encodedTradingPairText = HttpUtility.UrlEncode(tradingPairText);

            var url = $"{EngineRoot}dp?symbol={encodedTradingPairText}";
            return _httpWebClient.GetSync(url);
        }

        public string GetBalanceRaw(CossApiKey apiKey)
        {
            const string Path = "account/balances";
            return AuthenticatedGet(TradeRoot, apiKey, Path);
        }

        public List<CossBalanceItem> GetBalance(CossApiKey apiKey) => GetAndDeserialize<List<CossBalanceItem>>(() => GetBalanceRaw(apiKey));

        public string GetOpenOrdersRaw(CossApiKey apiKey, string symbol, string baseSymbol)
        {
            const string Path = "order/list/open";

            return AuthenticatedPost(TradeRoot, apiKey, Path, () =>
            {
                var cossSymbol = $"{symbol}-{baseSymbol}".ToLower();
                var nonce = GenerateNonce();

                var payload = new Dictionary<string, object>
                {
                    { "limit", 10 },
                    { "page", 0 },
                    { "symbol", cossSymbol.ToLower() },
                    { "timestamp", nonce },
                    { "recvWindow", DefaultReceiveWindow }
                };

                return JsonConvert.SerializeObject(payload);
            });
        }

        public CossGetOpenOrdersResponseMessage GetOpenOrders(CossApiKey apiKey, string symbol, string baseSymbol)
        {
            var contents = GetOpenOrdersRaw(apiKey, symbol, baseSymbol);
            return JsonConvert.DeserializeObject<CossGetOpenOrdersResponseMessage>(contents);
        }

        public string CreateOrderRaw(CossApiKey apiKey, string symbol, string baseSymbol, decimal price, decimal quantity, bool isBid)
        {
            const string Path = "/order/add";

            var tradingPairSymbol = GetTradingPairSymbol(symbol, baseSymbol);

            return AuthenticatedPost(TradeRoot, apiKey, Path, () =>
            {
                var payload = new CossCreateOrderRequestMessage
                {
                    OrderSymbol = tradingPairSymbol,
                    OrderPrice = price.ToString("G29"),
                    OrderSide = isBid ? "BUY" : "SELL",
                    OrderSize = quantity.ToString("G29"),
                    Type = "limit",
                    TimeStamp = GenerateNonce(),
                    RecvWindow = DefaultReceiveWindow
                };

                return JsonConvert.SerializeObject(payload);
            });
        }

        public CossCreateOrderResponseMessage CreateOrder(CossApiKey apiKey, string symbol, string baseSymbol, decimal price, decimal quantity, bool isBid)
        {
            var contents = CreateOrderRaw(apiKey, symbol, baseSymbol, price, quantity, isBid);
            return contents != null
                ? JsonConvert.DeserializeObject<CossCreateOrderResponseMessage>(contents)
                : null;
        }

        public string CancelOrderRaw(CossApiKey apiKey, string symbol, string baseSymbol, string orderId)
        {
            const string Path = "order/cancel";
            const string Verb = "DELETE";

            return AuthenticatedPost(TradeRoot, apiKey, Path, () =>
            {
                var combo = $"{symbol}_{baseSymbol}".ToUpper();

                var payload = new CossCancelOrderRequestMessage
                {
                    OrderId = orderId,
                    OrderSymbol = combo,
                    TimeStamp = GenerateNonce(),
                    RecvWindow = DefaultReceiveWindow
                };

                return JsonConvert.SerializeObject(payload);
            }, Verb);
        }

        public CossCancelOrderResponseMessage CancelOrder(CossApiKey apiKey, string symbol, string baseSymbol, string orderId)
            => GetAndDeserialize<CossCancelOrderResponseMessage>(() => CancelOrderRaw(apiKey, symbol, baseSymbol, orderId));

        public string GetCompletedOrdersRaw(CossApiKey apiKey, string symbol, string baseSymbol, int? limit = null, int? page = null)
        {
            const string Path = "order/list/completed";

            return AuthenticatedPost(TradeRoot, apiKey, Path, () =>
            {
                var combo = $"{symbol}_{baseSymbol}".ToUpper();

                var payload = new CossGetCompletedOrdersRequestMessage
                {
                    Symbol = combo,
                    RecvWindow = DefaultReceiveWindow,
                    TimeStamp = GenerateNonce(),
                    Limit = limit,
                    Page = page
                };

                return JsonConvert.SerializeObject(payload);
            });
        }

        public CossGetCompletedOrdersResponseMessage GetCompletedOrders(CossApiKey apiKey, string symbol, string baseSymbol, int? limit = null, int? page = null)
        {
            var contents = GetCompletedOrdersRaw(apiKey, symbol, baseSymbol, limit, page);
            var data = JsonConvert.DeserializeObject<CossGetCompletedOrdersResponseMessage>(contents);

            return data;
        }

        public string GetAccountDetailsRaw(CossApiKey apiKey)
        {
            const string Path = "account/details";

            return AuthenticatedGet(TradeRoot, apiKey, Path);
        }

        public CossAccountDetails GetAccountDetails(CossApiKey apiKey) => GetAndDeserialize<CossAccountDetails>(() => GetAccountDetailsRaw(apiKey));

        public string GetServerTimeRaw()
        {
            const string Path = "time";
            var url = $"{TradeRoot}{Path}";
            return _httpWebClient.GetSync(url);
        }

        public long GetServerTime()
        {
            var contents = GetServerTimeRaw();
            var serverTimeResponse = JsonConvert.DeserializeObject<Dictionary<string, long>>(contents);
            return serverTimeResponse["server_time"];
        }       

        private static long _nonceAdjustment = 0;

        public void SynchronizeTime()
        {
            var startTime = _dateTimeUtil.UtcNow;
            var serverTime = GetServerTime();
            var stopTime = _dateTimeUtil.UtcNow;

            var startTimeAsNonce = _dateTimeUtil.GetUnixTimeStamp13Digit(startTime);
            var stopTimeAsNonce = _dateTimeUtil.GetUnixTimeStamp13Digit(stopTime);

            var millisAfterStart = serverTime - startTimeAsNonce;
            var millisBeforeStop = stopTimeAsNonce - serverTime;

            var roundTrip = stopTimeAsNonce - startTimeAsNonce;

            if (serverTime < startTimeAsNonce)
            {
                _nonceAdjustment = serverTime - startTimeAsNonce - 25;
            }
        }

        private string GetTradingPairSymbol(string symbol, string baseSymbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) { throw new ArgumentNullException(nameof(symbol)); }
            if (string.IsNullOrWhiteSpace(baseSymbol)) { throw new ArgumentNullException(nameof(baseSymbol)); }

            return $"{symbol.Trim().ToUpper()}_{baseSymbol.Trim().ToUpper()}";
        }

        private string AuthenticatedGet(string rootUrl, CossApiKey apiKey, string path, Dictionary<string, object> pay = null, string verb = null)
        {
            var unjoined = new Dictionary<string, object>();
            if (pay != null)
            {
                foreach (var key in pay.Keys)
                {
                    unjoined[key] = pay[key];
                }
            }

            unjoined["recvWindow"] = DefaultReceiveWindow;
            unjoined["timestamp"] = GenerateNonce();

            var payload = string.Join("&", unjoined.Keys.OrderBy(key => key).Select(key => $"{key}={unjoined[key]}"));
            var url = $"{rootUrl}{path}?{payload}";

            var signature = _signator.SignPayload(apiKey.PrivateKey, payload);

            var headers = new Dictionary<string, string>
            {
                { "X-Requested-With", "XMLHttpRequest" },
                { "Authorization", apiKey.PublicKey },
                { "Signature", signature }
            };

            return _httpWebClient.HttpSync(url, "GET", null, "application/json", headers);
        }

        private string AuthenticatedPost(string rootUrl, CossApiKey apiKey, string path, Func<string> payloadGenerator, string verb = null)
        {
            var url = $"{rootUrl}{path}";

            var payloadText = payloadGenerator != null ? payloadGenerator() : null;
            var payloadBytes = Encoding.ASCII.GetBytes(payloadText);
            var signature = _signator.SignPayload(apiKey.PrivateKey, payloadText);

            var headers = new Dictionary<string, string>
            {
                { "X-Requested-With", "XMLHttpRequest" },
                { "Authorization", apiKey.PublicKey },
                { "Signature", signature }
            };

            return _httpWebClient.HttpSync(url, !string.IsNullOrWhiteSpace(verb) ? verb : "POST", payloadBytes, "application/json", headers);
        }

        private static DateTime? LastSyncTime = null;
        private static object GenerateNonceLocker = new object();

        // 13 digit unix timestamp
        private string GenerateNonce()
        {
            lock (GenerateNonceLocker)
            {
                if (!LastSyncTime.HasValue || (_dateTimeUtil.UtcNow - LastSyncTime >= TimeSpan.FromMinutes(10)))
                {
                    SynchronizeTime();
                    LastSyncTime = _dateTimeUtil.UtcNow;
                }

                var nonce = _dateTimeUtil.GetUnixTimeStamp13Digit() + _nonceAdjustment;
                return nonce.ToString();
            }
        }

        private T GetAndDeserialize<T>(Func<string> reader)
        {
            var contents = reader();
            return !string.IsNullOrWhiteSpace(contents)
                ? JsonConvert.DeserializeObject<T>(contents)
                : default(T);
        }
    }
}
