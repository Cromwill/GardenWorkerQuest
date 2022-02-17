using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanParticleCreator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Transform _point;
    private RaycastHandler _raycastHandler;

    private void OnEnable()
    {
        _raycastHandler = FindObjectOfType<RaycastHandler>();
        _raycastHandler.TouchedInteractable += CreateParticle;
    }

    private void OnDisable()
    {
        _raycastHandler.TouchedInteractable -= CreateParticle;
    }

    private void CreateParticle(Vector3 position)
    {
        Instantiate(_particle, _point.position, Quaternion.identity);
    }
}
