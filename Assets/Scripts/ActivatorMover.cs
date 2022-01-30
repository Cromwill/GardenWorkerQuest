using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(RayfireActivator))]
public class ActivatorMover : MonoBehaviour
{
    [SerializeField] private RaycastHandler _raycastHandler;

    private RayfireActivator _activator;

    private void Start()
    {
        _activator = GetComponent<RayfireActivator>();
    }

    private void OnEnable()
    {
        _raycastHandler.TouchedInteractable += Move;
    }

    private void OnDisable()
    {
        _raycastHandler.TouchedInteractable -= Move;
    }

    private void Move(Vector3 position)
    {
        _activator.transform.position = position;
    }
}
