using System.Collections;
using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public event Action OnAttackFinished;
    public event Action OnWeaponCreated;

    [SerializeField] private Transform _weaponHolder;
    [SerializeField] private Transform _arm;
    [SerializeField] private WeaponSet weaponState;
    private Hero _hero;
    private float _lastAttackTime;
    private float _attackDuration;

    public Weapon Weapon { get; private set; }

    void Awake()
    {
        _hero = GetComponent<Hero>();
    }

    private void Start()
    {
        InstWeapon(weaponState);
    }

    public void InstWeapon(WeaponSet weapon)
    {
        if (_weaponHolder.GetComponentInChildren<Weapon>() != null)
            Destroy(_weaponHolder.GetComponentInChildren<Weapon>().gameObject);

        if (_arm.childCount > 0)
            Destroy(_arm.GetChild(0).gameObject);

        Instantiate(weapon.WeaponModelArm, _arm);
        _attackDuration = weapon.AttackTime;

        var newWeapon = Instantiate(weapon.WeaponPrefab, _weaponHolder);
        Weapon = newWeapon.GetComponent<Weapon>();

        _hero.GetAnimator.runtimeAnimatorController = weapon.Animator;
        Weapon.Owner = _hero;

        OnWeaponCreated?.Invoke();
    }

    public void Attack()
    {
        if (Time.time > _attackDuration + _lastAttackTime)
        {
            _lastAttackTime = Time.time;
            _hero.StartAttack(_attackDuration);
            StartCoroutine(WaitAndAttackWeapon(_attackDuration / 2));
        }
    }

    private IEnumerator WaitAndAttackWeapon(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _hero.MakePlayerEffects();
        Weapon.Attack();
        OnAttackFinished?.Invoke();
    }
}
