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
    [SerializeField] private float _angle;

    private Rigidbody _rigidbody;
    public bool _isGrabed;
    public HandPointer _hand;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _hand = FindObjectOfType<HandPointer>();
        _hand.MouseDown += Grab;
    }

    private void OnDisable()
    {
        _hand.MouseDown -= Grab;
    }

    private void OnMouseDrag()
    {
        if (_isGrabed == false)
            return;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hitInfo;

        //if (Physics.Raycast(ray, out hitInfo, 100, _flyZone))
        //        transform.position = new Vector3(hitInfo.point.x, _flyHight, hitInfo.point.z);

        Vector3 offset = new Vector3(0, -0.5f, 0);
        transform.position = _hand.transform.position + offset;
    }

    private void OnMouseDown()
    {
        _rigidbody.isKinematic = true;
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, _angle, transform.rotation.eulerAngles.z));
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _isGrabed = false;
    }

    private void Grab(Vector2 a)
    {
        _isGrabed = true;
    }
}
