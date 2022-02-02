using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Interactable
{
    [SerializeField] private int _durability;
    [SerializeField] private bool _BreakeOnHold;

    public event Action DurabilityEnded;

    public override void OnInteract()
    {
        if (_BreakeOnHold == false)
        {
            LowDurability();
        }
    }

    public override void OnHolded()
    {
        if(_BreakeOnHold)
        {
            LowDurability();
        }    
    }

    protected void LowDurability()
    {
        _durability--;

        if (_durability <= 0)
        {
            DurabilityEnded?.Invoke();
        }
    }
}
