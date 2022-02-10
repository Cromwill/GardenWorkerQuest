using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTask : Task
{
    [SerializeField] private Cutable[] _cutable;

    private void Awake()
    {
        _cutable = FindObjectsOfType<Cutable>();
        MaxValue = _cutable.Length;
    }

    private void OnEnable()
    {
        foreach (var cutable in _cutable)
        {
            cutable.Cuted += CheckComplition;
        }
    }

    private void OnDisable()
    {
        foreach (var cutable in _cutable)
        {
            cutable.Cuted -= CheckComplition;
        }
    }
}
