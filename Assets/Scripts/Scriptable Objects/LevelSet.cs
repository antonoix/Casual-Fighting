using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Set", menuName = "Weapon Set", order = 52)]
public class LevelSet : ScriptableObject
{
    [SerializeField] private GameObject[] _weaponSets;
    [SerializeField] private GameObject _locationSet;

    public GameObject[] HeroSet => _weaponSets;
    public GameObject LocationSet => _locationSet;
}
