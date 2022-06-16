using System;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : ISystemInput
{
    public event Action<Vector3> OnDirectionChanged;
    public event Action OnTouchEnded;

    private Vector2 _startPos;

    private RectTransform _img;

    public MobileInput(RectTransform img)
    {
        _img = img;
    }

    public void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPos = touch.position;
                _img.gameObject.SetActive(true);
                _img.position = touch.position;
            }
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                OnDirectionChanged?.Invoke(GetDirection(touch));
            }
            if (touch.phase == TouchPhase.Ended)
            {
                _img.gameObject.SetActive(false);
                OnTouchEnded?.Invoke();
            }
        }
    }

    private Vector2 GetDirection(Touch touch)
    {
        var direction = (touch.position - _startPos) / (Screen.width / 6);
        direction = new Vector2(Mathf.Clamp(direction.x, -1, 1), Mathf.Clamp(direction.y, -1, 1));
        return direction;
    }
}
