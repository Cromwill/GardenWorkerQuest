using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTask : Task
{
    [SerializeField] private Shredder[] _shredders;

    private void Awake()
    {
        _shredders = FindObjectsOfType<Shredder>();
        MaxValue = FindObjectsOfType<Dragable>().Length;
    }

    private void OnEnable()
    {
        foreach (var shredder in _shredders)
        {
            shredder.DragableRecieved += CheckComplition;
        }
    }

    private void OnDisable()
    {
        foreach (var shredder in _shredders)
        {
            shredder.DragableRecieved -= CheckComplition;
        }
    }
}
