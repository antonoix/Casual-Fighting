using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour, IAim
{
    private IAim _currentAim;

    private Hero _hero;
    private Attacker _attacker;
    private Weapon _weapon;

    public event System.Action<Bot> OnAimLost;
    public event System.Action<IAim> OnDestroyed;

    private void Awake()
    {
        _hero = GetComponent<Hero>();
        _attacker = GetComponent<Attacker>();
        _attacker.OnWeaponCreated += SetWeapon;
        _attacker.OnAttackFinished += () => { OnAimLost?.Invoke(this); };
    }

    private void SetWeapon()
    {
        _attacker.OnWeaponCreated -= SetWeapon;

        _weapon = _attacker.Weapon;
        _weapon.OnCollidedHero += MakeAttack;


        OnAimLost?.Invoke(this);
    }

    private void MakeAttack()
    {
        if (!_currentAim.Equals(null))
            transform.LookAt(_currentAim.transform);
        StartCoroutine(WaitAndAttack(0.5f));
    }

    public void FindAim(IAim aim)
    {
        _currentAim = aim;
        StopAllCoroutines();
        StartCoroutine(MoveTo(Random.Range(5, 11)));
    }

    private IEnumerator WaitAndAttack(float secondsWait)
    {
        yield return new WaitForSeconds(secondsWait);
        _attacker.Attack();
    }

    private IEnumerator MoveTo(float seconds)
    {
        bool canAttack = false;
        var startTime = Time.time;
        while(Time.time < startTime + seconds)
        {
            if (_currentAim.Equals(null))
                break;
            if (Vector3.Distance(transform.position, _currentAim.transform.position) > 2)
            {
                MakeMoving();
            }
            else
            {
                _hero.SetRunningAnimation(false);
                canAttack = _weapon.AimToAttack != null;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        if (canAttack)
        {
            MakeAttack();
        }
        else
        {
            OnAimLost?.Invoke(this);
        }
    }

    private void MakeMoving()
    {
        _hero.SetRunningAnimation(true);
        _hero.Move(_currentAim);
        transform.LookAt(_currentAim.transform);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        OnDestroyed?.Invoke(this);
    }
}
