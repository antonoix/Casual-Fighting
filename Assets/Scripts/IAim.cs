using System;
using System.Collections.Generic;
using UnityEngine;

public interface IAim
{
    event Action<IAim> OnDestroyed;

    Transform transform { get; }
}
