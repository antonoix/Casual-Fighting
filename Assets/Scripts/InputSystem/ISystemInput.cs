using System;
using UnityEngine;

public interface ISystemInput 
{
    public event Action<Vector3> OnDirectionChanged;
    public event Action OnTouchEnded;

    public void CheckTouch();
}
