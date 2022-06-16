using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Button _buttonRetry;
    [SerializeField] private Button _buttonNextLvl;
    [SerializeField] private PraiseText _praiseTextPrefab;
    public RectTransform TouchPoint;

    private readonly string[] _gameTexts = new string[2] { "GOOD", "PERFECT" };
    private readonly string[] _educationTexts = 
        new string[3] { "Так держать, еще двое!", "Остался последний противник!", "Обучение пройдено!" };

    public void ActivateRestart()
    {
        _buttonRetry.gameObject.SetActive(true);
    }

    public void ActivateNextLvl()
    {
        _buttonNextLvl.gameObject.SetActive(true);
    }

    public void CreatePraiseText(int value, bool education = false)
    {
        var txt = Instantiate(_praiseTextPrefab.gameObject, transform);
        if (education)
            txt.GetComponent<PraiseText>().SetText(value, _educationTexts);
        else
            txt.GetComponent<PraiseText>().SetText(value, _gameTexts);
    }
}
