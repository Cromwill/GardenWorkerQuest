using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointingArrow : MonoBehaviour
{
    [SerializeField] private Image _arrowView;
    [SerializeField] private QuestPoint _target;

    [SerializeField] private ArrowCanvas _arrowCanvas;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _arrowCanvas = FindObjectOfType<ArrowCanvas>();
    }

    private void Update()
    {
        float minX = _arrowView.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = _arrowView.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(_target.transform.position);

        if (Vector3.Dot((_target.transform.position - transform.position), transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(_target.transform.position);
        bool isOffScreen = targetPositionScreenPoint.x <= 0 || targetPositionScreenPoint.x >= Screen.width || targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y >= Screen.height;
        
        _arrowView.gameObject.SetActive(isOffScreen);

        RotateTowards(targetPositionScreenPoint);

        _arrowView.transform.position = pos;
    }

    public void SetTarget(QuestPoint questPoint)
    {
        _target = questPoint;
    }

    public void SetImage(Image arrowImage)
    {
        _arrowView = arrowImage;
    }

    private void RotateTowards(Vector3 positiOnScreen)
    {
        Vector3 toPosition = positiOnScreen;
        Vector3 fromPosition = _arrowCanvas.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
        _arrowView.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, angle);
    }
}

