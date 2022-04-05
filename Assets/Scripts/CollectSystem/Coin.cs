using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void Collect(Collecting hero)
    {
        Bank.AddCoins(1);
        StartCoroutine(PlayEffectAndDestroy());
    }

    private IEnumerator PlayEffectAndDestroy()
    {
        Sounds.Instance.PlayCoinAudio();
        var particles = GetComponentInChildren<ParticleSystem>();
        particles.Play();

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
