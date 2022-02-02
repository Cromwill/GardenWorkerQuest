using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Rigidbody))]
public class Dragable : Interactable
{
    [SerializeField] private LayerMask _flyZone;
    [SerializeField] private float _flyHight = 1f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100, _flyZone))
                transform.position = new Vector3(hitInfo.point.x, _flyHight, hitInfo.point.z);
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
