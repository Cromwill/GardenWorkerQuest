using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable: MonoBehaviour
{
    public event Action Taped;

    private void OnEnable()
    {
        Taped += OnInteract;
    }

    private void OnDisable()
    {
        Taped -= OnInteract;
    }

    public virtual void Interact() { Taped?.Invoke(); }

    public virtual void Interact(Vector2 mousePosition){ }

    public virtual void OnInteract() { }
}
