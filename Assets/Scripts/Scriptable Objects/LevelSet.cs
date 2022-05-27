using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Set", menuName = "Level Set", order = 52)]
public class LevelSet : ScriptableObject
{
    [SerializeField] private Bot[] _bots;
    [SerializeField] private GameObject _locationSet;

    public Bot[] HeroSet => _bots;
    public GameObject LocationSet => _locationSet;
}
