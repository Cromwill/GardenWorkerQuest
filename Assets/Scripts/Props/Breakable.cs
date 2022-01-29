using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Interactable
{
    private int _durability = 100;
    private int _durabilityPerTap = 25;

    public event Action DurabilityEnded;

    public override void OnInteract()
    {
        LowDurability();
    }

    private void LowDurability()
    {
        _durability -= _durabilityPerTap;

        if (_durability <= 0)
        {
            DurabilityEnded?.Invoke();
        }
    }
}
