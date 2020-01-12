# CossSharp
### A .NET client for the Coss.io crypto exchange.  

Official API documentation: https://api.coss.io/v1/spec  
Exchange: https://coss.io/  

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

## Synchronizing Clocks
The private API calls use a nonce based on your machine's clock.  
The your clock and the Coss server's clock aren't in sync, your API call will fail.
The SynchronizeTime() gets the time from Coss's server and adjusts the nonce it sends accordingly.
I call this method every few minutes to avoid errors.

```CSharp
// Call this method every few minutes. It works wonders.
_cossClient.SynchronizeTime();
```

## API Key
Some API methods, such as GetOrderBook(), can be called by anyone without an API key.  
The API methods that affect your account require an API key.  
Consider carefully how you will store and retrieve this key.  
If someone gets a hold of your key, they could steal your funds.  

## How to build
You can use either Visual Studio (Community edition is succificient) or Visual Studio Code to build.  
Visual Studio is a full IDE geared towards (but not exclusive to) .NET and runs on Windows.
Visual Studio Code is a gereralized IDE based on Atom and runs on Windows, Linux, and Mac.
Both can be downloaded for free.
On the Raspberry Pi and Chrome Book, you can use headmelted's distribution of Visual Studio Code. https://code.headmelted.com/  

