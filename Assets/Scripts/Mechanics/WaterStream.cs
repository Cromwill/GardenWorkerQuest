using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dweiss;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer), typeof(Rigidbody))]
public class WaterStream : MonoBehaviour
{
    [SerializeField] private float timeBeteenStep = 1f;
    [SerializeField] private int stepCount = 30;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private FlowerActivator _flowerActivator;

    private float _streampPressure;
    private float _maxStreamPressure = 10f;
    private float _minStreamPressure = 4f;
    private LineRenderer _trajectory;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _streampPressure = _minStreamPressure;
        _trajectory = GetComponent<LineRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            IncreaseStreamPressure();
        else
            DecreaseStreamPressure();

        var trajectoryPositions = _rigidbody.CalculateMovement(stepCount, timeBeteenStep, transform.forward * _streampPressure, transform.forward * _streampPressure);

        _trajectory.positionCount = stepCount + 1;
        _trajectory.SetPosition(0, transform.position);

        for (int i = 0; i < trajectoryPositions.Length; ++i)
        {
            _trajectory.SetPosition(i + 1, trajectoryPositions[i]);

            if (_trajectory.GetPosition(i).y >= 0 && _trajectory.GetPosition(i).y<=0.5f)
            {
                _flowerActivator.transform.position = _trajectory.GetPosition(i);
            }
        }
    }

    private void IncreaseStreamPressure()
    {
        _streampPressure = Mathf.MoveTowards(_streampPressure, _maxStreamPressure, _changeSpeed * Time.deltaTime);
    }

    private void DecreaseStreamPressure()
    {
        _streampPressure = Mathf.MoveTowards(_streampPressure, _minStreamPressure, _changeSpeed * Time.deltaTime);
    }
}
