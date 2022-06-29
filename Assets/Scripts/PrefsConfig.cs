using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo: Refactor to JSON/XML
public class PrefsConfig
{
    private const string _coins = "Coins";
    private const string _educated = "Educated";
    private const string _sizeRatio = "SizeRatio";
    private const string _speedRatio = "SpeedRatio";
    private const string _soundsOff = "SoundsOff";
    private const string _level = "Level";

    public static string Coins { get { CheckForKey(_coins, 0); return _coins; } }
    public static string Educated { get { CheckForKey(_educated, 0); return _educated; } }
    public static string SizeRatio { get { CheckForKey(_sizeRatio, 0f); return _sizeRatio; } }
    public static string SpeedRatio { get { CheckForKey(_speedRatio, 0f); return _speedRatio; } }
    public static string SoundsOff { get { CheckForKey(_soundsOff, 0); return _soundsOff; } }
    public static string Level { get  { CheckForKey(_level, 1); return _level; } }

    private static void CheckForKey(string key, int defaultValue = 0)
    {
        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetInt(key, defaultValue);
    }

    private static void CheckForKey(string key, float defaultValue = 0f)
    {
        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetFloat(key, defaultValue);
    }
}
