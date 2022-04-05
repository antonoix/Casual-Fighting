using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private float _speed;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, _speed * 10 * Time.deltaTime, 0));
    }
}
