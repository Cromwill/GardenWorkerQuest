using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _workAlways;
    [SerializeField] private bool _reverseMoving;

    public bool HitedConstrain;
    private Rigidbody _rigidbody;
    private float _minTime = 0.5f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Move()
    {
        Vector3 calculatedPosition = _rigidbody.position;

        if (_reverseMoving)
            _rigidbody.position -= transform.forward * CalculatedSpeed();
        else
            _rigidbody.position += transform.forward * CalculatedSpeed();

        _rigidbody.MovePosition(calculatedPosition);
    }

    private float CalculatedSpeed()
    {
        return _speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0) || _workAlways )
        {
            StartCoroutine(MoveCoroutine());
        }
    }

    private IEnumerator MoveCoroutine()
    {
        float timePassed = 0;

        while (timePassed < _minTime && HitedConstrain == false)
        {
            Vector3 calculatedPosition = _rigidbody.position;

            timePassed += Time.deltaTime;

            if (_reverseMoving)
                _rigidbody.position -= transform.forward * CalculatedSpeed();
            else
                _rigidbody.position += transform.forward * CalculatedSpeed();

            _rigidbody.MovePosition(calculatedPosition);

            yield return null;
        }
    }
}
