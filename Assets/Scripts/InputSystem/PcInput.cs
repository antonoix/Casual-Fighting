using System;
using UnityEngine;

public class PcInput : ISystemInput
{
    public event Action<Vector3> OnDirectionChanged;
    public event Action OnTouchEnded;

    private Vector2 _startPos;
    private RectTransform _img;

    public PcInput(RectTransform img)
    {
        _img = img;
    }

    public void CheckTouch()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _startPos = Input.mousePosition;
            if (_startPos.y < Screen.height * 0.8f)
            {
                _img.gameObject.SetActive(true);
                _img.position = Input.mousePosition;
            }
        }
        if (Input.GetButton("Fire1"))
        {
            OnDirectionChanged?.Invoke(GetDirection(Input.mousePosition));
        }
        if (Input.GetButtonUp("Fire1"))
        {
            _img.gameObject.SetActive(false);
            OnTouchEnded?.Invoke();

        }
    }

    private Vector2 GetDirection(Vector2 touchPos)
    {
        var direction = (touchPos - _startPos) / (Screen.width / 12);
        Debug.Log(direction);
        direction = new Vector2(Mathf.Clamp(direction.x, -1, 1), Mathf.Clamp(direction.y, -1, 1));
        return direction;
    }
}
