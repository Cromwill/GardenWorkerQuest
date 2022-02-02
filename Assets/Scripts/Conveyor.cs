using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    private float _speed = 0.5f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Move()
    {
        Vector3 calculatedPosition = _rigidbody.position;
        _rigidbody.position += Vector3.left * _speed * Time.deltaTime;
        _rigidbody.MovePosition(calculatedPosition);
    }


    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
            Move();
    }
}
