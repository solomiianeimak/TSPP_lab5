using System;

public interface ICurrencyConverter
{
    double Convert(double amount, string fromCurrency, string toCurrency);
}

public class BankAPI
{
    public double GetRate(string currencyPair)
    {
        if (currencyPair == "USD_UAH") return 43.90;
        if (currencyPair == "EUR_UAH") return 51.56;
        return 1.0;
    }
}

public class CryptoExchangeAPI
{
    public double FetchRate(string from, string to)
    {
        if (from == "BTC" && to == "USD") return 3444431.43;
        if (from == "USD" && to == "BTC") return 1.0 / 3444431.43;
        return 1.0;
    }
}

public class BankAdapter : ICurrencyConverter
{
    private readonly BankAPI _bankAPI = new BankAPI();

    public double Convert(double amount, string fromCurrency, string toCurrency)
    {
        string pair = $"{fromCurrency}_{toCurrency}";
        double rate = _bankAPI.GetRate(pair);
        return amount * rate;
    }
}

public class CryptoAdapter : ICurrencyConverter
{
    private readonly CryptoExchangeAPI _cryptoAPI = new CryptoExchangeAPI();

    public double Convert(double amount, string fromCurrency, string toCurrency)
    {
        double rate = _cryptoAPI.FetchRate(fromCurrency, toCurrency);
        return amount * rate;
    }
}

class Program
{
    static void PrintConversion(ICurrencyConverter converter, double amount, string from, string to)
    {
        double result = converter.Convert(amount, from, to);
        Console.WriteLine($"{amount} {from} = {result:F2} {to}");
    }

    static void Main()
    {
        ICurrencyConverter bank = new BankAdapter();
        ICurrencyConverter crypto = new CryptoAdapter();

        PrintConversion(bank, 100, "USD", "UAH");
        PrintConversion(bank, 50, "EUR", "UAH");
        PrintConversion(crypto, 1, "BTC", "USD");
    }
}
