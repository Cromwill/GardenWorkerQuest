using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Breakable : Interactable
{
    private int _durability = 100;
    private int _durabilityPerTap = 25;
    private Rigidbody _rigidBody;

    public event Action DurabilityEnded;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public override void OnInteract()
    {
        LowDurability();
    }

    private void LowDurability()
    {
        _durability -= _durabilityPerTap;

        if (_durability <= 0)
        {
            _rigidBody.isKinematic = false;
            DurabilityEnded?.Invoke();
        }
    }
}
