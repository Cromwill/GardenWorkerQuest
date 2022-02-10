using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParitcles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _changeSpeed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            IncreaseParticlesSpeed();
        else
            DecreaseParticlesSpeed();
    }

    private void IncreaseParticlesSpeed()
    {
        _particles.startSpeed = Mathf.MoveTowards(_particles.startSpeed, _maxSpeed, _changeSpeed * Time.deltaTime);
    }

    private void DecreaseParticlesSpeed()
    {
        _particles.startSpeed = Mathf.MoveTowards(_particles.startSpeed, _minSpeed, _changeSpeed * Time.deltaTime);
    }
}
