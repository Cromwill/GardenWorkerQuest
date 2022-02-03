using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutable : Breakable
{
    [SerializeField] private Breakable _firstArea;
    [SerializeField] private Breakable _secondArea;

    private bool _isFirstAreaPassed;
    private bool _isSecondAreaPassed;
    private float timeStamp1;
    private float timeStamp2;

    public Action Cuted;

    private void OnEnable()
    {
        _firstArea.DurabilityEnded += FirstAreaPassed;
        _secondArea.DurabilityEnded += SeconAreaPassed;
    }

    private void OnDisable()
    {
        _firstArea.DurabilityEnded -= FirstAreaPassed;
        _secondArea.DurabilityEnded -= SeconAreaPassed;
    }

    private void FirstAreaPassed()
    {
        _isFirstAreaPassed = true;
        timeStamp1 = Time.time;

        if (CanBeCuted())
        {
            Cut();
        }
    }

    private void SeconAreaPassed()
    {
        _isSecondAreaPassed = true;
        timeStamp2 = Time.time;

        if (CanBeCuted())
        if (CanBeCuted())
        {
            Cut();
        }
    }

    private bool CanBeCuted()
    {
        return _isFirstAreaPassed && _isSecondAreaPassed && (Mathf.Abs(timeStamp2 - timeStamp1)<0.1f);
    }

    private void Cut()
    {
        DisableAreas();
        LowDurability();
        Cuted?.Invoke();
    }

    private void DisableAreas()
    {
        _firstArea.GetComponent<Collider>().enabled = false;
        _secondArea.GetComponent<Collider>().enabled = false;
    }
}