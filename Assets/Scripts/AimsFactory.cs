using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimsFactory : MonoBehaviour
{ 
    public Bot SpawnBot(Bot prefab)
    {
        return Instantiate(prefab.gameObject, transform).GetComponent<Bot>();
    }
}
