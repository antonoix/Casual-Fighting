using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hero))]
public class Collecting : MonoBehaviour
{
    public Hero CollectingHero { get; private set; }

    private void Start()
    {
        CollectingHero = GetComponent<Hero>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICollectable>(out var loot))
        {
            loot.Collect(this);
        }
    }
}
