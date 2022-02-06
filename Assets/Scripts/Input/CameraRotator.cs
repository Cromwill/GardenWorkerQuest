using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        xRotation = transform.localEulerAngles.x;
        yRotation = transform.localEulerAngles.y;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float pointerX = Input.GetAxis("Mouse X") * _speed * Time.deltaTime;
            float pointerY = Input.GetAxis("Mouse Y") * _speed * Time.deltaTime;

            xRotation -= pointerY;
            yRotation += pointerX;

            xRotation = Mathf.Clamp(xRotation, -15f, 15f);
            yRotation = Mathf.Clamp(yRotation, -15f, 15f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}
