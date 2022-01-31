using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Rigidbody))]
public class Dragable : Interactable
{
    private float _flySpeed = 0.008f;
    private bool _isDestinatioReached;
    private Rigidbody _rigidbody;
    private bool _isDraged;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator FlyTo(Vector3 Destination, GameObject obj)
    {
        while (obj.transform.position != Destination && _isDraged)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, Destination, _flySpeed);

            yield return null;
        }

        if(_isDraged == true)
            _isDestinatioReached = true;
    }

    private void OnMouseDrag()
    {
        _isDraged = true;
        _rigidbody.isKinematic = true;

        Vector3 positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOnScreen.z));
        transform.position = mouseWorldPosition;

        if (_isDestinatioReached == false)
            StartCoroutine(FlyTo(new Vector3(-0.5f, 1.5f, -0.9f), transform.GetChild(0).gameObject));
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = false;
        _isDraged = false;
        ResetPosition();
    }

    public void ResetPosition()
    {
        Transform child = transform.GetChild(0);
        transform.DetachChildren();
        transform.position = child.transform.position;
        child.SetParent(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Shredder shredder))
            _isDraged = false;
    }
}
