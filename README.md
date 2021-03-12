[![Nuget](https://img.shields.io/nuget/v/Irensaltali.Currency.svg)](https://www.nuget.org/packages/Irensaltali.Currency)
![GitHub](https://img.shields.io/github/license/irensaltali/currency-dotnet.svg)
![GitHub top language](https://img.shields.io/github/languages/top/irensaltali/currency-dotnet.svg)

# currency-dotnet

.NET Core Currency API. Supports two different data sources. If you need more please create new issue. Data sources:

* [Fixer](http://bit.ly/3bHiQrC)
* CBRT (Central Bank of The Republic Of Turkey)

For Fixer you will need API Key. You can get it from [here](https://bit.ly/30Ire3P).New data soruces will be added.

# Frameworks

.NET 4.7.2, .NET Core 2.1, .NET 5

# Installation

The library is distributed on `NuGet`. To install the latest version, run the following command in the Package Manager Console:

```sh
PM> Install-Package Irensaltali.Currency
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

[Twitter](https://twitter.com/irensaltali) - [LinkedIn](https://linkedin.com/in/irensaltali) - [Stack Overflow](https://stackoverflow.com/users/3453221/iren) - [Medium](irensaltali.medium.com) - [reddit](https://www.reddit.com/user/irensaltali)
