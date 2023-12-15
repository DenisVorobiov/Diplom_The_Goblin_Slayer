using System;

public interface ICurrencySystem
{
    Currency SoftCurrency { get; }
    Currency HardCurrency { get; }
}

public class CurrencySystem : ICurrencySystem
{
    private const string SaveKeySoft = "currency_soft";
    private const string SaveKeyHard = "currency_hard";
    public Currency SoftCurrency { get; }
    public Currency HardCurrency { get; }
    private ISaveSystem _saveSystem;

    public CurrencySystem()
    {
        _saveSystem = Context.Instance.SaveSystem;
        SoftCurrency = InitCurrency(SaveKeySoft, 100, "Gold");
        HardCurrency = InitCurrency(SaveKeyHard, 10, "Crystal");

        SoftCurrency.OnChanged += Save;
        HardCurrency.OnChanged += Save;
    }

    private Currency InitCurrency(string key, int initialValue, string currencyName)
    {
        var currency = _saveSystem.Load<Currency>(key);
        if (currency == null)
        {
            currency = new Currency(initialValue, currencyName);
        }

        return currency;
    }

    private void Save()
    {
        _saveSystem.Save(SaveKeySoft, SoftCurrency);
        _saveSystem.Save(SaveKeyHard, HardCurrency);
    }
}