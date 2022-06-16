using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TranslatedText : MonoBehaviour
{
    [SerializeField] private string _textId;

    void Start()
    {
        if (TryGetComponent<Text>(out var txt))
            txt.text = Localization.GetTranslated(_textId);
        if (TryGetComponent<TMP_Text>(out var txtTMP))
            txtTMP.text = Localization.GetTranslated(_textId);
    }
}
