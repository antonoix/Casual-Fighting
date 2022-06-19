using UnityEngine.UI;
using UnityEngine;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void Start()
    {
        _toggle.isOn = PlayerPrefs.GetInt(PrefsConfig.SoundsOff) == 0;
    }

    public void DisableSounds(bool tog)
    {
        int soundsOff = tog ? 0 : 1;
        PlayerPrefs.SetInt(PrefsConfig.SoundsOff, soundsOff);
    }
}
