using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

    [SerializeField] private Transform targetFinish;
    [SerializeField] private float translateSpeed;

    private Hero _targetHero;

    void Start()
    {
        _targetHero = target.GetComponent<Hero>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            var targetPosition = target.position + offset * _targetHero.Multiplier;
            transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetFinish.position, translateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
