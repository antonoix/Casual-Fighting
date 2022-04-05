using System;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour, IAim
{
    public event Action<IAim> OnDestroyed;

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
