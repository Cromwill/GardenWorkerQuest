using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTheFlowerTask : Task
{
    private Flower[] _flowers;

    private void Awake()
    {
        _flowers = FindObjectsOfType<Flower>();
        _counter = _flowers.Length;
    }

    private void OnEnable()
    {
        foreach (var flower in _flowers)
        {
            flower.Growed += CheckComplition;
        }
    }

    private void OnDisable()
    {
        foreach (var flower in _flowers)
        {
            flower.Growed -= CheckComplition;
        }
    }
}
