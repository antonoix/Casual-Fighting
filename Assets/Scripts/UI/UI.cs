using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Button _buttonRetry;
    [SerializeField] private Button _buttonNextLvl;
    [SerializeField] private PraiseText _praiseTextPrefab;

    private void Start()
    {
        GameState.Instance.OnFailed += ActivateRestart;
        GameState.Instance.OnWin += ActivateNextLvl;
    }

    private void ActivateRestart()
    {
        _buttonRetry.gameObject.SetActive(true);
    }

    private void ActivateNextLvl()
    {
        _buttonNextLvl.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameState.Instance.OnFailed -= ActivateRestart;
        GameState.Instance.OnWin -= ActivateNextLvl;
    }

    public void CreatePraiseText(int value)
    {
        var txt = Instantiate(_praiseTextPrefab.gameObject, transform);
        txt.GetComponent<PraiseText>().SetText(value);
    }
}
