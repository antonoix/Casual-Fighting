using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BotsSet : ScriptableObject
{
    public Bot[] prefabs;

    public float minSpeed;
    public float maxSpeed;
}
