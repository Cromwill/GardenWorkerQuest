using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMover : MonoBehaviour
{  
    [SerializeField] private InputActionAdapter _handler;
    [SerializeField] private float _speed;

    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _handler.MoveCalled += Move;
    }

    private void OnDisable()
    {
        _handler.MoveCalled -= Move;
    }

    private void Move(Vector3 StickDirection)
    {
        Vector3 direction = new Vector3(-StickDirection.y, 0, StickDirection.x);

        _rigidBody.MovePosition(transform.position + direction * _speed * Time.deltaTime);

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
