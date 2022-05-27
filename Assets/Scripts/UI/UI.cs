using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Button _buttonRetry;
    [SerializeField] private Button _buttonNextLvl;
    [SerializeField] private PraiseText _praiseTextPrefab;

    public void ActivateRestart()
    {
        _buttonRetry.gameObject.SetActive(true);
    }

    public void ActivateNextLvl()
    {
        _buttonNextLvl.gameObject.SetActive(true);
    }

    public void CreatePraiseText(int value)
    {
        var txt = Instantiate(_praiseTextPrefab.gameObject, transform);
        txt.GetComponent<PraiseText>().SetText(value);
    }
}
