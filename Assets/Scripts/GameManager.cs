using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Hero _hero;
    [SerializeField] AimsFactory _factory;
    [SerializeField] BotsSet _set;
    [SerializeField] UI _ui;

    private State _currentState;

    private enum State
    {
        Playing,
        Won,
        Lost
    }

    private void Awake()
    {
        _currentState = State.Playing;
        _hero.OnDied += HandleHeroDeath;
        AimsManager aims = new AimsManager(_set, _factory);
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
        _currentState = State.Lost;
        Sounds.Instance.PlayLoseSound();
        _ui.ActivateRestart();
    }

    public void MakeWin()
    {
        if (_currentState == State.Lost)
            return;
        _currentState = State.Won;
        Sounds.Instance.PlayWinSound();
        _ui.ActivateNextLvl();
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}
