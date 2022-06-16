using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Set", menuName = "Level Set", order = 52)]
public class LevelSet : ScriptableObject
{
    [SerializeField] private LootWeapon[] _weapons;
    [SerializeField] private LootShoes[] _shoes;
    [SerializeField] private Coin[] _coins;
    [SerializeField] private GameObject _locationSet;

    public LootWeapon[] Weapons => _weapons;
    public LootShoes[] Shoes => _shoes;
    public Coin[] Coins => _coins;
    public GameObject LocationSet => _locationSet;
}
