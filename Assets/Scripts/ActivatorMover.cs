using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(RayfireActivator))]
public class ActivatorMover : MonoBehaviour
{
    [SerializeField] private RaycastHandler _raycastHandler;
    [SerializeField] private bool _moveOnHold;

    private RayfireActivator _activator;

    private void Start()
    {
        _activator = GetComponent<RayfireActivator>();
    }

    private void OnEnable()
    {
        if (_moveOnHold)
            _raycastHandler.HoldedOnInteractable += Move;
        else
            _raycastHandler.TouchedInteractable += Move;
    }

    private void OnDisable()
    {
        if (_moveOnHold)
            _raycastHandler.HoldedOnInteractable += Move;
        else
            _raycastHandler.TouchedInteractable += Move;
    }

    private void Move(Vector3 position)
    {
        _activator.transform.position = position;
    }
}
