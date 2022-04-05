using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero data", menuName = "Hero Data", order = 51)]
public class WeaponSet : ScriptableObject
{
    [SerializeField] private AnimatorOverrideController _animation;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _weaponModelInArm;

    [SerializeField] private float _attackTime;

    public float AttackTime => _attackTime;

    public AnimatorOverrideController Animator
    {
        get { return _animation; }
    }

    public GameObject WeaponPrefab
    {
        get { return _weaponPrefab; }
    }

    public GameObject WeaponModelArm
    {
        get { return _weaponModelInArm; }
    }
}
