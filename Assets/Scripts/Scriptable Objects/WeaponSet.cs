using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon data", menuName = "Weapon Data", order = 51)]
public class WeaponSet : ScriptableObject
{
    [SerializeField] private AnimatorOverrideController _animation;
    [SerializeField] private GameObject _weaponArea;
    [SerializeField] private GameObject _weaponModelInArm;

    [SerializeField] private float _attackTime;

    public float AttackTime => _attackTime;

    public AnimatorOverrideController Animator
    {
        get { return _animation; }
    }

    public GameObject WeaponPrefab
    {
        get { return _weaponArea; }
    }

    public GameObject WeaponModelArm
    {
        get { return _weaponModelInArm; }
    }
}
