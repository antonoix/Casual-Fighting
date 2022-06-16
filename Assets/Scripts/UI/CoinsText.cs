using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Bank.CoinsUpdated += UpdateCoins;
        UpdateCoins(Bank.CoinsCount);
    }

    private void UpdateCoins(int count)
    {
        _text.text = Localization.GetTranslated("coins") + count;
    }

    private void OnDestroy()
    {
        Bank.CoinsUpdated -= UpdateCoins;
    }
}
