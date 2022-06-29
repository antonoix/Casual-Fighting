using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;

    [SerializeField] private Transform _targetFinish;
    [SerializeField] private float _translateSpeed;

    void FixedUpdate()
    {
        if (_target != null)
        {
            var targetPosition = _target.position + _offset * _target.localScale.x;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _translateSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _targetFinish.position, _translateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
