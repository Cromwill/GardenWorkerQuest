using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class RayFireInitializer : MonoBehaviour
{
    [SerializeField] private RayfireRigid _rayFireRidid;
    [SerializeField] private Breakable _breakable;
    [SerializeField] private bool _demolishOnDurabilityEnd;

    private void OnEnable()
    {
        _breakable.DurabilityEnded += Init;

        if(_demolishOnDurabilityEnd)
            _breakable.DurabilityEnded += Demolish;
    }

    private void OnDisable()
    {
        _breakable.DurabilityEnded -= Init;

        if (_demolishOnDurabilityEnd)
            _breakable.DurabilityEnded -= Demolish;
    }

    private void Init()
    {
        _rayFireRidid.Initialize();
    }

    private void Demolish()
    {
        _rayFireRidid.Demolish();
    }
}
