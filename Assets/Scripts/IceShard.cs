using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class IceShard : Interactable
{
    [SerializeField] private RayfireActivator _activator;

    private int _tapToActivate;

    private void Awake()
    {
        _tapToActivate = Random.Range(1, 3);
    }

    public override void OnInteract()
    {
        if(IsBroken())
            _activator.transform.position = transform.position;
    }

    private bool IsBroken()
    {
        _tapToActivate -= 1;

        return _tapToActivate <= 0;
    }
}
