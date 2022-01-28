using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Breakable))]
public class Icicle : MonoBehaviour
{
    public event Action Broked;
    private bool CanBeBroked;
    private Breakable _breakable;

    private void OnEnable()
    {
        _breakable = GetComponent<Breakable>();
        _breakable.DurabilityEnded += SetCanBeBroked;
    }

    private void OnDisable()
    {
        _breakable.DurabilityEnded -= SetCanBeBroked;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Ground ground) && CanBeBroked)
        {
            Breaking();
        }
    }

    public void Breaking()
    {
        Broked?.Invoke();
        gameObject.SetActive(false);
    }

    private void SetCanBeBroked()
    {
        CanBeBroked = true;
    }
}
