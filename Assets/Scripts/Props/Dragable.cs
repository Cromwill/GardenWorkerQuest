using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Rigidbody))]
public class Dragable : Interactable
{
    [SerializeField] private LayerMask _mask;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100, _mask))
                transform.position = new Vector3(hitInfo.point.x, 1f, hitInfo.point.z);
    }

    private void OnMouseDown()
    {
        _rigidbody.isKinematic = true;
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = false;
    }
}
