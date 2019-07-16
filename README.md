[![Nuget](https://img.shields.io/nuget/v/Irensaltali.Currency.svg)](https://www.nuget.org/packages/Irensaltali.Currency)
![GitHub](https://img.shields.io/github/license/irensaltali/currency-dotnet.svg)
![GitHub top language](https://img.shields.io/github/languages/top/irensaltali/currency-dotnet.svg)

# currency-dotnet
.NET Core Currency API. Exchange rate data is taken from the TCMB (Türkiye Cumhuriyeti Merkez Bankası - Central Bank of The Republic Of Turkey). 

New data soruces will be added.

# Frameworks

.NET 4.7.2, .NET Core 2.0, .NET Core 2.1, .NET Core 2.2 


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
[Twitter](https://twitter.com/irensaltali) - [LinkedIn](https://linkedin.com/in/irensaltali) - [Stack Overflow](https://stackoverflow.com/users/3453221/iren)
