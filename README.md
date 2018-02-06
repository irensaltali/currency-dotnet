# currency-dotnetcore
.NET Core Currency API. Exchange rate data is taken from the TCMB (Türkiye Cumhuriyeti Merkez Bankası - Central Bank of The Republic Of Turkey). New data soruces will be added.

# Requirements

Min .NET Core 2.0

# Usage

```csharp
CurrencyConverter currencyConverter = new CurrencyConverter();
double rate = currencyConverter.GetRate(Currency.TRY, Currency.USD);
double exchange = currencyConverter.Convert(Currency.USD, Amount, Currency.TRY) 
```

# Contact
@irensaltali
