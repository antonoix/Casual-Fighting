using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootShoes : MonoBehaviour, ICollectable
{
    [SerializeField] private ParticleSystem _particles;

    public void Init(int secondsBeforeDestroy)
    {
        Invoke(nameof(MakeEffectAndDestroy), secondsBeforeDestroy);
    }

    public void Collect(Collecting hero)
    {
        hero.CollectingHero.IncreaseSpeed(1.3f);
        MakeEffectAndDestroy();
    }

    private void MakeEffectAndDestroy()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
