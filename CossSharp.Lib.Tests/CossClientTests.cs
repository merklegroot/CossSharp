using CossSharp.Lib;
using CossSharp.Lib.Http;
using CossSharp.Lib.Models;
using CossSharp.Lib.Signator;
using CossSharp.Lib.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CossSharp.Lib.Tests
{
    [TestClass]
    public class CossClientTests
    {
        private CossApiKey _apiKey;

        private Mock<ICossSignator> _cossSignator;
        private Mock<IDateTimeUtil> _dateTimeUtil;
        private Mock<IHttpWebClient> _httpWebClient;

        private CossClient _cossClient;

        private const long ServerTime = 1549057935149;

        private DateTime _currentTimeUtc = new DateTime(2019, 2, 1, 21, 52, 15, DateTimeKind.Utc);

        [TestInitialize]
        public void Initialize()
        {
            _apiKey = new CossApiKey { PublicKey = "public key goes here", PrivateKey = "private key goes here" };

            _cossSignator = new Mock<ICossSignator>();
            _dateTimeUtil = new Mock<IDateTimeUtil>();
            _dateTimeUtil.Setup(mock => mock.UtcNow).Returns(() =>
            {
                try { return _currentTimeUtc; }
                finally { _currentTimeUtc = _currentTimeUtc.AddSeconds(1); }
            });

            _dateTimeUtil.Setup(mock => mock.GetUnixTimeStamp13Digit()).Returns(() =>
            {
                return new DateTimeUtil().GetUnixTimeStamp13Digit(_dateTimeUtil.Object.UtcNow);
            });

            _httpWebClient = new Mock<IHttpWebClient>();

            _httpWebClient.Setup(mock => mock.GetSync("https://trade.coss.io/c/api/v1/time")).Returns(() =>
                $"{{\"server_time\":{ServerTime}}}");

            _cossClient = new CossClient(_cossSignator.Object, _dateTimeUtil.Object, _httpWebClient.Object);
        }

        [TestMethod]
        public void Get_balance()
        {
            _cossClient.GetBalance(_apiKey);
            _httpWebClient.Verify(mock => mock.HttpSync("https://trade.coss.io/c/api/v1/account/balances?recvWindow=10000&timestamp=1549057938000", "GET", null, "application/json", It.IsAny<Dictionary<string, string>>()));
        }

        [TestMethod]
        public void Get_account_details()
        {
            _cossClient.GetAccountDetails(_apiKey);
            _httpWebClient.Verify(mock => mock.HttpSync("https://trade.coss.io/c/api/v1/account/details?recvWindow=10000&timestamp=1549057938000", "GET", null, "application/json", It.IsAny<Dictionary<string, string>>()));
        }

        [TestMethod]
        public void Cancel_order()
        {
            _cossClient.CancelOrder(_apiKey, "ETH", "BTC", "1234");
            _httpWebClient.Verify(mock => mock.HttpSync("https://trade.coss.io/c/api/v1/order/cancel", "DELETE", It.IsAny<byte[]>(), "application/json", It.IsAny<Dictionary<string, string>>()));
        }

        [TestMethod]
        public void Get_order_book()
        {
            _cossClient.GetOrderBookRaw("KAYA", "ETH");
            _httpWebClient.Verify(mock => mock.GetSync("https://engine.coss.io/api/v1/dp?symbol=KAYA_ETH"));
        }
    }
}
