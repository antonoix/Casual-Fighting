using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapon : MonoBehaviour, ICollectable
{
    public WeaponSet WeaponToLoot;

    public void Collect(Collecting hero)
    {
        hero.GetComponent<Attacker>().InstWeapon(WeaponToLoot);

        StartCoroutine(MakeEffectAndDestroy());
    }

    private IEnumerator MakeEffectAndDestroy()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
