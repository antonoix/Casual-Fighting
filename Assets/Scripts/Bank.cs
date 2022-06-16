using System;
using System.Collections.Generic;
using UnityEngine;

public class Bank
{
    public static event Action<int> CoinsUpdated;
    public static int _coinsCount;
    public static int CoinsCount { get { return CheckIfPrefExists(); } }

    public static void AddCoins(int count)
    {
        _coinsCount = CheckIfPrefExists() + count;
        PlayerPrefs.SetInt(PrefsConfig.Coins, _coinsCount);
        CoinsUpdated?.Invoke(_coinsCount);
    }

    private static int CheckIfPrefExists()
    {
        if (!PlayerPrefs.HasKey(PrefsConfig.Coins))
            PlayerPrefs.SetInt(PrefsConfig.Coins, 0);
        _coinsCount = PlayerPrefs.GetInt(PrefsConfig.Coins);
        return _coinsCount;
    }
}
