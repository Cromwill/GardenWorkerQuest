using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Icicle))]
public class IciclePartcleHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    private Icicle _icicle;

    private void OnEnable()
    {
        _icicle = GetComponent<Icicle>();
        _icicle.Broked += OnBreaking;
    }

    private void OnDisable()
    {
        _icicle.Broked -= OnBreaking;
    }

    private void OnBreaking()
    {
        _particles.transform.parent = null;
        _particles.Play();
    }
}
