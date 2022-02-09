using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrowthActivator : MonoBehaviour
{
    [SerializeField] private Task _task;

    private Flower[] _flowers;

    private void Awake()
    {
        _flowers = GetComponentsInChildren<Flower>();
    }

    private void OnEnable()
    {
        if(_task !=null)
            _task.Complete += Activate;
    }

    private void OnDisable()
    {
        if (_task != null)
            _task.Complete -= Activate;
    }

    private void Activate()
    {
        foreach (var flower in _flowers)
        {
            flower.Grow();
        }
    }
}
