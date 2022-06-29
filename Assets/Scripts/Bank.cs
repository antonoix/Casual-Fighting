using System;
using System.Collections.Generic;
using UnityEngine;

public class Bank
{
    public static event Action<int> CoinsUpdated;
    public static int CoinsCount { get { return PlayerPrefs.GetInt(PrefsConfig.Coins); } private set { } }

    public static void AddCoins(int count)
    {
        CoinsCount = PlayerPrefs.GetInt(PrefsConfig.Coins) + count;
        PlayerPrefs.SetInt(PrefsConfig.Coins, CoinsCount);
        CoinsUpdated?.Invoke(CoinsCount);
    }
}
