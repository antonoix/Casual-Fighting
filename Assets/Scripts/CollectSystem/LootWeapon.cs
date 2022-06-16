using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapon : MonoBehaviour, ICollectable
{
    public WeaponSet WeaponToLoot;

    public void Init(int secondsBeforeDestroy)
    {
        StartCoroutine(MakeEffectAndDestroy(secondsBeforeDestroy));
    }

    public void Collect(Collecting hero)
    {
        hero.GetComponent<Attacker>().InstWeapon(WeaponToLoot);
        StartCoroutine(MakeEffectAndDestroy());
    }

    private IEnumerator MakeEffectAndDestroy(int secondsDelay = 0)
    {
        if (secondsDelay > 0)
            yield return new WaitForSeconds(secondsDelay);

        GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
