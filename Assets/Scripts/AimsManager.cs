using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AimsManager
{
    private BotsSet _botsSet;
    private AimsFactory _factory;

    private List<Bot> _bots;
    private List<IAim> _aims;

    public AimsManager(BotsSet setOfBots, AimsFactory factory)
    {
        _botsSet = setOfBots;
        _factory = factory;
        _bots = new List<Bot>();
        _aims = new List<IAim>();
        
        SpawnBots();
        FillAims();
    }

    private void FillAims()
    {
        foreach (Transform e in _factory.transform)
            if (e.TryGetComponent<IAim>(out var aim))
                _aims.Add(aim);
    }

    public void SpawnBots()
    {
        foreach (var botPrefab in _botsSet.prefabs)
        {
            var newBot = _factory.SpawnBot(botPrefab);
            _bots.Add(newBot);

            newBot.OnDestroyed += RemoveBot;
            newBot.OnAimLost += SetAim;
        }
    }

    private void RemoveBot(IAim bot)
    {
        _bots.Remove((Bot)bot);
        if (_bots.Count == 0)
            GameState.Instance.MakeWin();
    }

    private void SetAim(Bot bot)
    {
        bot.FindAim(_aims[Random.Range(0, _aims.Count)]);
    }
}
