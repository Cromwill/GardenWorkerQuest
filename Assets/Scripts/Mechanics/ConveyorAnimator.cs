using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAnimator : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float _ySpeed;
    [SerializeField] private float _xSpeed;

    private float yOffset;
    private float xOffset;

    private void Update()
    {
        yOffset += _ySpeed * Time.deltaTime;
        xOffset += _xSpeed * Time.deltaTime;

        _material.mainTextureOffset = new Vector2(xOffset, yOffset);
    }
}
