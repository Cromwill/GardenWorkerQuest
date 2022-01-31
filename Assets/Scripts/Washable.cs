using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washable : Interactable
{
    [SerializeField] private float _scaleToDestroy = 0.00001f;
    [SerializeField] private float _scalePerTick = 0.0001f;

    public override void OnHolded()
    {
        transform.localScale -= new Vector3(_scalePerTick, _scalePerTick, _scalePerTick);

        if (transform.localScale.x <= _scaleToDestroy || transform.localScale.y <= _scaleToDestroy)
            gameObject.SetActive(false);
    }
}
