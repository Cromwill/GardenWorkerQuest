using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dweiss;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer), typeof(Rigidbody))]
public class WaterStream : MonoBehaviour
{
    [SerializeField] private float timeBeteenStep = 1;
    [SerializeField] private int stepCount = 30;
    [SerializeField] private float _streampPressure;
    [SerializeField] private FlowerActivator _flowerActivator;

    private LineRenderer _trajectory;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _trajectory = GetComponent<LineRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
}
