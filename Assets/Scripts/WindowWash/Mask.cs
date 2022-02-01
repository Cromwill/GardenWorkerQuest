using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Image))]
public class Mask : MonoBehaviour
{
    [SerializeField] private int _touchRadius;
    [SerializeField] private Texture2D _texture;
    [SerializeField] private RectTransform _rectTransform;

    private int _width;
    private int _hight;

    public Action OnTouch;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _width = (int)_rectTransform.sizeDelta.x;
        _hight = (int)_rectTransform.sizeDelta.y;

        Reset();
    }

    public void Erase(int xCenter, int yCenter)
    {
        int xOffset;
        int yOffset;
        int xPos;
        int yPos;
        int yRange;

        Color32[] tempColors = _texture.GetPixels32();
        bool hasChanged = false;

        for (xOffset = -_touchRadius; xOffset <= _touchRadius; xOffset++)
        {
            yRange = (int)Mathf.Ceil(Mathf.Sqrt(_touchRadius * _touchRadius - xOffset * xOffset));
            for (yOffset = -yRange; yOffset <= yRange; yOffset++)
            {
                xPos = xCenter + xOffset;
                yPos = yCenter + yOffset;
                hasChanged = TryErasePixel(xPos, yPos, ref tempColors);
            }
        }

        if (hasChanged)
        {
            OnTouch?.Invoke();
            _texture.SetPixels32(tempColors);
            _texture.Apply(false);
        }

    }

    private bool TryErasePixel(int xPos, int yPos, ref Color32[] tempColors)
    {
        if(xPos >=0 && xPos <_width && yPos>=0 && yPos < _hight)
        {
            int index = yPos * _width + xPos;

            if(tempColors[index].a > 0)
            {
                tempColors[index].a = 0;
                return true;
            }
        }

        return false;
    }

    private void Reset()
    {
        _texture = new Texture2D(_width, _hight);
        Color32[] colors = _texture.GetPixels32();

        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color32(0, 0, 0, 255);
        }

        _texture.SetPixels32(colors);

        GetComponent<Image>().material.mainTexture = _texture;
        _texture.Apply(false);
    }
}
