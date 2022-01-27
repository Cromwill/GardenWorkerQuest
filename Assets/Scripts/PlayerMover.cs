using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMover : MonoBehaviour
{  
    [SerializeField] private InputHandler _handler;
    
    private float _speed = 10;
    private Vector3 _direction;

    private void OnEnable()
    {
        _handler.MoveCalled += Move;
    }

    private void OnDisable()
    {
        _handler.MoveCalled -= Move;
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        Rotate(direction);
    }

    private void Rotate(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = lookRotation;
    }
}
