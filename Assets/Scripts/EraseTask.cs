using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseTask : Task
{
    private Eraseable[] _masks;

    private void Awake()
    {
        _masks = FindObjectsOfType<Eraseable>();
        _counter = _masks.Length;
    }

    private void OnEnable()
    {
        _counter = _masks.Length;

        foreach (var mask in _masks)
        {
            mask.Completed += CheckComplition;
        }
    }

    private void OnDisable()
    {
        foreach (var mask in _masks)
        {
            mask.Completed -= CheckComplition;
        }
    }
}
