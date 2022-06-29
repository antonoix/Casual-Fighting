using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Hero _hero;
    [SerializeField] AimsFactory _factory;
    [SerializeField] BotsSet[] _sets;
    [SerializeField] UI _UI;

    [SerializeField] private YandexAds _ads;
    private State _currentState;

    private enum State
    {
        Playing,
        Won,
        Lost
    }

    private void Awake()
    {
        ISystemInput input = new PcInput(_UI.TouchPoint);

        _currentState = State.Playing;
        _hero.OnDied += HandleHeroDeath;
        _hero.GetComponent<Controllable>().Init(input);
        AimsManager aims = new AimsManager(_sets[UnityEngine.Random.Range(0, _sets.Length)], _factory);
        aims.OnAllEnemiesDied += MakeWin;
    }

    private void HandleHeroDeath(IAim aim)
    {
        MakeFailed();
    }

    public void MakeFailed()
    {
        if (_currentState == State.Won)
            return;

        _ads.ShowInterstitial();
        _currentState = State.Lost;
        Sounds.Instance.PlayLoseSound();
        _UI.ActivateRestart();
    }

    public void MakeWin()
    {
        if (_currentState == State.Lost)
            return;
        _currentState = State.Won;
        Sounds.Instance.PlayWinSound();
        _UI.ActivateNextLvl();
        PlayerPrefs.SetInt(PrefsConfig.Level, PlayerPrefs.GetInt(PrefsConfig.Level) + 1);
    }
}
