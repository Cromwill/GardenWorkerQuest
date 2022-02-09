using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Collider))]
public class RayFireInitializer : MonoBehaviour
{
    [SerializeField] private RayfireRigid _rayFireRidid;
    [SerializeField] private Breakable _breakable;
    [SerializeField] private bool _demolishOnDurabilityEnd;

    private Collider _collider;

    private void OnEnable()
    {
        _collider = GetComponent<Collider>();

        if (_breakable != null)
            _breakable.DurabilityEnded += Activate;

        if(_demolishOnDurabilityEnd)
            _breakable.DurabilityEnded += Demolish;
    }

    private void OnDisable()
    {
        if (_breakable != null)
            _breakable.DurabilityEnded -= Activate;

        if (_demolishOnDurabilityEnd)
            _breakable.DurabilityEnded -= Demolish;
    }

    private void Activate()
    {
        _rayFireRidid.Activate();
        _collider.enabled = false;
        _breakable.enabled = false;
    }

    public void Init(RayfireRigid rigid)
    {
        rigid.Initialize();
    }

    private void Demolish()
    {
        _rayFireRidid.Demolish();
    }
}
