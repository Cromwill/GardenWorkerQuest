using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class CutLogTask : Task
{
    [SerializeField] private int _sliceAmount;

    private void OnEnable()
    {
        MaxValue = _sliceAmount;
        RFDemolitionEvent.GlobalEvent += OnSliced;
    }

    private void OnDisable()
    {
        RFDemolitionEvent.GlobalEvent -= OnSliced;
    }

    private void OnSliced(RayfireRigid rigid)
    {
        CheckComplition();
    }
}
