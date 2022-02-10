using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTask : Task
{
    [SerializeField] private Breakable[] _breakables;
    
    private void Awake()
    {
        _breakables = FindObjectsOfType<Breakable>();
        MaxValue = _breakables.Length;
    }

    private void OnEnable()
    {
        foreach (var breakable in _breakables)
        {
            breakable.Destroyed += CheckComplition;
        }
    }

    private void OnDisable()
    {
        foreach (var breakable in _breakables)
        {
            breakable.Destroyed -= CheckComplition;
        }
    }
}
