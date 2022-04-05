using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audioS;

    public static Sounds Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
        }
        else if (Instance == this)
        { 
            Destroy(gameObject); 
        }

        audioS = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        audioS.clip = (AudioClip)Resources.Load("Spell_01");
        audioS.Play();
    }

    public void PlayCoinAudio()
    {
        audioS.clip = (AudioClip)Resources.Load("Gold");
        audioS.Play();
    }

    public void PlayLoseSound()
    {
        if (audioS == null)
            return;
        audioS.clip = (AudioClip)Resources.Load("Lose");
        audioS.Play();
    }

    public void PlayWinSound()
    {
        audioS.clip = (AudioClip)Resources.Load("Win");
        audioS.Play();
    }
}
