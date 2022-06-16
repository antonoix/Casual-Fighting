using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event Action OnAttackFinished;

    [SerializeField] private Material _material;

    public event Action OnCollidedHero;

    public Hero AimToAttack { get; protected set; }

    public Hero Owner { get; set; }

    public virtual void Attack()
    {
        StartCoroutine(MakeAttackEffects());

        if (AimToAttack != null)
            Kill(AimToAttack);
    }

    private IEnumerator MakeAttackEffects()
    {
        GetComponentInChildren<ParticleSystem>().Play();

        var renderer = GetComponent<Renderer>();
        Material oldMaterial = renderer.material;
        renderer.material = _material;

        yield return new WaitForSeconds(0.5f);
        renderer.material = oldMaterial;
        OnAttackFinished?.Invoke();
    }

    protected virtual void Kill(Hero _aim)
    {
        _aim.Die(Owner);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Hero>(out var hero))
        {
            AimToAttack = hero;
            OnCollidedHero?.Invoke();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent<Hero>(out var hero))
        {
            AimToAttack = null;
        }
    }
}
