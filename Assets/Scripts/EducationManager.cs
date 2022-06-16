using TMPro;
using UnityEngine;

public class EducationManager : MonoBehaviour
{
    [SerializeField] Hero _player;
    [SerializeField] UI _ui;
    [SerializeField] Hero[] _bots;

    private int _killCount;

    void Awake()
    {
        ISystemInput input = new PcInput(_ui.TouchPoint);
        _player.GetComponent<Controllable>().Init(input);
        _player.SetEducation(true);
        foreach (var bot in _bots)
        {
            bot.OnDied += HandleBotDeath;
        }
    }

    private void HandleBotDeath(IAim bot)
    {
        _ui.CreatePraiseText(++_killCount, true);
        if (_killCount == 3)
        {
            _ui.ActivateNextLvl();
            PlayerPrefs.SetInt(PrefsConfig.Educated, 1);
        }        
    }
}
