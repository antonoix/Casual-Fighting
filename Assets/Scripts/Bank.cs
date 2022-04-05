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
        PlayerPrefs.SetInt("Coins", _coinsCount);
        CoinsUpdated?.Invoke(_coinsCount);
    }

    private static int CheckIfPrefExists()
    {
        if (!PlayerPrefs.HasKey("Coins"))
            PlayerPrefs.SetInt("Coins", 0);
        _coinsCount = PlayerPrefs.GetInt("Coins");
        return _coinsCount;
    }
}
