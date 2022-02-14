using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class LogConstrain : MonoBehaviour
{
    private Conveyor _conveyor;

    private void Start()
    {
        _conveyor = FindObjectOfType<Conveyor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RayfireRigid logRigid))
            _conveyor.HitedConstrain = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out RayfireRigid logRigid))
            _conveyor.HitedConstrain = false;
    }
}
