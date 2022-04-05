using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    [SerializeField] AimsFactory _factory;
    [SerializeField] BotsSet _set;

    public event Action OnFailed;
    public event Action OnWin;

    private void Awake()
    {
        Instance = this;
        AimsManager aims = new AimsManager(_set, _factory);
    }

    public void MakeFailed()
    {
        Sounds.Instance.PlayLoseSound();
        OnFailed?.Invoke();
    }

    public void MakeWin()
    {
        Sounds.Instance.PlayWinSound();
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        OnWin?.Invoke();
    }
}
