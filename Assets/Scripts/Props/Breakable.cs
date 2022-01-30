using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Interactable
{
    [SerializeField] private int _durability;

    public event Action DurabilityEnded;

    public override void OnInteract()
    {
        LowDurability();
    }

    private void LowDurability()
    {
        _durability--;

        if (_durability <= 0)
        {
            DurabilityEnded?.Invoke();
        }
    }
}
