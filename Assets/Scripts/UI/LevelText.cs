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
            string.Format("Level: {0}", PlayerPrefs.GetInt("Level"));
    }
}
