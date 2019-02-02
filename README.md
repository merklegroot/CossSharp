# CossSharp
### A .NET client for the Coss.io crypto exchange.  

Official API documentation: https://api.coss.io/v1/spec  
Exchange: https://coss.io/  

## Other languages
#### Not into C#? Give one of these other clients a try.
I am not affiliated with any of the projects listed below.  
Python: https://github.com/Shdjfjsks/pyCOSS/  
Node.js: https://github.com/cryptodeal/Coss-API-Node  
CCXT also supports the Coss API. https://github.com/ccxt/ccxt 

## Examples
### Initializing
```CSharp
var cossClient = new CossClient();
var apiKey = new CossApiKey { PublicKey = "YOUR_PUBLIC_KEY", PrivateKey = "YOUR_PRIVATE_KEY" };
```

### Place an order
```CSharp
var orderResult = cossClient.CreateOrder(apiKey, "ETH", "BTC", 0.02m, 0.03m, true);
Console.WriteLine($"Order {orderResult.OrderId} is {orderResult.Status}.");
```
```
Order a89effdd-ed49-4bec-b441-b22343f87889 is open.
```

### Get your account balance
```CSharp
var balanceItems = cossClient.GetBalance(apiKey);
foreach (var balanceItem in balanceItems)
{
    Console.WriteLine($"{balanceItem.CurrencyCode}: {balanceItem.Total}");
}
```
```
ETH: 4.10562274
COSS: 1500.83481096
FYN: 3200.00000000
```

### Get an order book
```CSharp
var orderBook = cossClient.GetOrderBook("NEO", "BTC");
var bestBid = orderBook.Bids.OrderByDescending(queryBid => queryBid.Price).FirstOrDefault();
var bestAsk = orderBook.Asks.OrderBy(queryBid => queryBid.Price).FirstOrDefault();

Console.WriteLine("NEO-BTC");
Console.WriteLine($"Best Ask Price: {bestAsk.Price}");
Console.WriteLine($"Best Bid Price: {bestBid.Price}");
```
```
NEO-BTC
Best Ask Price: 0.00211200
Best Bid Price: 0.00198100
```

## Serialized vs Raw result methods
Methods have both a serialized and a raw version.
When caching, I prefer to store the original response text instead of the serialized result.
Use whichever verison suits your workflow best.

```CSharp
var orderBook = cossClient.GetOrderBook("NEO", "BTC");
```
vs
```CSharp
var _orderBookCache = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

var timeStampUtc = DateTime.UtcNow;
var contents = cossClient.GetOrderBookRaw("NEO", "BTC");

// Cache the results to later.
_orderBookCache["NEO_BTC"] = new { TimeStampUtc = timeStampUtc, Contents = contents };

// And deserialized it manually.
var orderBook = JsonConvert.DeserializeObject<CossOrderBook>(contents);

```
The "raw" version is there to make caching the results easier.
If you don't want to cache your results, just use the regular version.

## API Key
Some API methods, such as GetOrderBook(), can be called by anyone without an API key.  
The API methods that affect your account require an API key.  
Consider carefully how you will store and retrieve this key.  
If someone gets a hold of your key, they could steal your funds.  

## How to build
You can use either Visual Studio or Visual Studio Code to build.  
Windows is needed for Visual Studio.  
Visual Studio Code runs on Windows, Linux, and Mac.  
For Raspberry Pi, you can use headmelted's distribution of Visual Studio Code. https://code.headmelted.com/  
