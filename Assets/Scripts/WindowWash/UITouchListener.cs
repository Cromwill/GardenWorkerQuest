using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public class UITouchListener : MonoBehaviour
{
    [SerializeField] Camera _uiCamera;

    public TouchEvent OnTouch;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, Input.mousePosition, _uiCamera, out Vector2 localPositionRectangle);
            OnTouch.Invoke((int)localPositionRectangle.x, (int)localPositionRectangle.y);
        }
    }

    [System.Serializable]
    public class TouchEvent : UnityEvent<int, int> { }
}

