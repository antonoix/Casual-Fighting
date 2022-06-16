using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AimsManager
{
    public event Action OnAllEnemiesDied;
    private readonly BotsSet _botsSet;
    private readonly AimsFactory _factory;

    private readonly List<Bot> _bots;
    private readonly List<IAim> _aims;

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
            OnAllEnemiesDied?.Invoke();
    }

    private void SetAim(Bot bot)
    {
        bot.FindAim(_aims[UnityEngine.Random.Range(0, _aims.Count)]);
    }
}
