using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _defaultPos;
    [SerializeField] private Vector3 _defaultRot;
    [SerializeField] private Vector3 _shopPos;
    [SerializeField] private Vector3 _shopRot;
    [SerializeField] private float _speed = 10;

    public void SetShopPosition()
    {
        StartCoroutine(MakeTransition(_shopPos, _shopRot));
    }

    public void SetDeafultPosition()
    {
        StartCoroutine(MakeTransition(_defaultPos, _defaultRot));
    }

    private IEnumerator MakeTransition(Vector3 finishPoint, Vector3 finishRotation)
    {
        (Vector3 StartPos, Vector3 StartRot) = (transform.position, transform.rotation.eulerAngles);
        float RotAndPosDifference = (transform.rotation.eulerAngles - finishRotation).magnitude /
            (transform.position - finishPoint).magnitude;

        while ((StartPos - transform.position).magnitude < (finishPoint - StartPos).magnitude)
        {
            var step = Time.deltaTime * _speed;
            transform.Translate((finishPoint - StartPos).normalized * step, Space.World);
            transform.Rotate((finishRotation - StartRot).normalized * step * RotAndPosDifference);
            yield return new WaitForFixedUpdate();
        }
    }

    
}
