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

    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        AudioListener.pause = silence;
        // Or / And
        AudioListener.volume = silence ? 0 : 1;
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
        if (audioS == null)
            return;
        audioS.clip = (AudioClip)Resources.Load("Win");
        audioS.Play();
    }
}
