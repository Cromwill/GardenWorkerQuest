using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable: MonoBehaviour
{
    public event Action Taped;
    public event Action Holded;

    private void OnEnable()
    {
        Taped += OnInteract;
        Holded += OnHolded;
    }

    private void OnDisable()
    {
        Taped -= OnInteract;
        Holded += OnHolded;
    }

    public virtual void Interact() { Taped?.Invoke(); }

    public virtual void Interact(Vector2 mousePosition){ Holded?.Invoke(); }

    public virtual void OnInteract() { }

    public virtual void OnHolded() { }
}
