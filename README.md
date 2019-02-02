# CossSharp
### A .NET client for the Coss.io crypto exchange.  

Official API documentation: https://api.coss.io/v1/spec  
Exchange: https://coss.io/  

## Examples
## Initializing
```CSharp
var cossClient = new CossClient();
var apiKey = new CossApiKey { PublicKey = "YOUR_PUBLIC_KEY", PrivateKey = "YOUR_PRIVATE_KEY" };
```

## Place an order
```CSharp
var orderResult = cossClient.CreateOrder(apiKey, "ETH", "BTC", 0.02m, 0.03m, true);
Console.WriteLine($"Order {orderResult.OrderId} is {orderResult.Status}.");
```
```
Order a89effdd-ed49-4bec-b441-b22343f87889 is open.
```

## Get your account balance
```CSharp
var balanceItems = _client.GetBalance(apiKey);
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