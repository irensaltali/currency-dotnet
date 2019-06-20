![Nuget](https://img.shields.io/nuget/v/Irensaltali.Currency.svg)

# currency-dotnetcore
.NET Core Currency API. Exchange rate data is taken from the TCMB (Türkiye Cumhuriyeti Merkez Bankası - Central Bank of The Republic Of Turkey). 

New data soruces will be added.

# Requirements

.NET Core 2.0


## Installation
The library is distributed on `NuGet`. To install the latest version, run the following command in the Package Manager Console: 
```sh
PM> Install-Package Irensaltali.Currency -Version 0.1.0-beta
```

# Usage

```csharp
CurrencyConverter currencyConverter = new CurrencyConverter();
double rate = currencyConverter.GetRate(Currency.TRY, Currency.USD);
double exchange = currencyConverter.Convert(Currency.USD, Amount, Currency.TRY) 
```

# Contact
[irensaltali.com](https://irensaltali.com "İren SALTALI Blog")

# Follow Me On
[Twitter](https://twitter.com/irensaltali) - [LinkedIn](https://linkedin.com/in/irensaltali) - [Stack Overflow](https://stackoverflow.com/users/3453221/iren)
