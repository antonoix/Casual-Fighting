using System;
using System.Collections.Generic;
using UnityEngine;

public class Growing
{
    private readonly Transform _heroTransform;

    public float Multiplier { get; private set; } = 1;

    public Growing(Transform heroTransform)
    {
        _heroTransform = heroTransform;
        Multiplier += PlayerPrefs.GetFloat(PrefsConfig.SizeRatio);
        _heroTransform.localScale = new Vector3(1, 1, 1) * Multiplier;
    }

    public void BecomeBigger(float multiplier)
    {
        Multiplier *= multiplier * 1.15f;
        _heroTransform.localScale = new Vector3(1, 1, 1) * Multiplier;
    }
}
