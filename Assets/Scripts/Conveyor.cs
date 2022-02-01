using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private InputActionAdapter _adapter;
    
    private float _speed = 1f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _adapter.Holded += Move;
    }

    private void OnDisable()
    {
        _adapter.Holded -= Move;
    }

    private void Move(Vector2 position)
    {
        Vector3 calculatedPosition = _rigidbody.position;
        _rigidbody.position += Vector3.left * _speed * Time.deltaTime;
        _rigidbody.MovePosition(calculatedPosition);
    }
}
