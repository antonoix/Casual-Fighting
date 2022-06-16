using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private const float _step = 0.03f;
    [SerializeField] private TextMeshProUGUI _sizeText;
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private TextMeshProUGUI _coinsText;

    private void Start()
    {
        SetPrefs(PrefsConfig.SizeRatio, 0, _sizeText);
        SetPrefs(PrefsConfig.SpeedRatio, 0, _speedText);
        _coinsText.text = PlayerPrefs.GetInt(PrefsConfig.Coins).ToString();
    }

    public void UpgradeSize()
    {
        if (PlayerPrefs.GetInt(PrefsConfig.Coins) >= 5)
        {
            PlayerPrefs.SetInt(PrefsConfig.Coins, PlayerPrefs.GetInt(PrefsConfig.Coins) - 5);
            SetPrefs(PrefsConfig.SizeRatio, _step, _sizeText);
            _coinsText.text = PlayerPrefs.GetInt(PrefsConfig.Coins).ToString();
        }
    }

    public void UpgradeSpeed()
    {
        if (PlayerPrefs.GetInt(PrefsConfig.Coins) >= 5)
        {
            PlayerPrefs.SetInt(PrefsConfig.Coins, PlayerPrefs.GetInt(PrefsConfig.Coins) - 5);
            SetPrefs(PrefsConfig.SpeedRatio, _step, _speedText);
            _coinsText.text = PlayerPrefs.GetInt(PrefsConfig.Coins).ToString();
        }
    }

    private void SetPrefs(string key, float step, TextMeshProUGUI text)
    {
        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetFloat(key, 0);

        PlayerPrefs.SetFloat(key, PlayerPrefs.GetFloat(key) + step);
        text.text = string.Format("+ {0}", PlayerPrefs.GetFloat(key).ToString());
    }
}
