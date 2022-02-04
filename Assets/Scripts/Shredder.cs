using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] private Collider _shredArea;

    public Action DragableRecieved;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Dragable _dragable))
        {
            DragableRecieved?.Invoke();
        }
    }
}
