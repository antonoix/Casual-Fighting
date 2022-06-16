using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
        GetComponent<TextMeshProUGUI>().text = 
            string.Format(Localization.GetTranslated("level") + PlayerPrefs.GetInt("Level"));
    }
}
