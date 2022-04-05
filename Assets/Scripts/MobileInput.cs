using System;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput
{
    public event Action<Vector3> OnDirectionChanged;
    public event Action OnTouchEnded;

    private Vector2 _startPos;

    public void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPos = touch.position;
            }
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                OnDirectionChanged?.Invoke(GetDirection(touch));
            }
            if (touch.phase == TouchPhase.Ended)
            {
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
