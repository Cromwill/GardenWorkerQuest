using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Task _task;

    private void OnEnable()
    {
        _task = FindObjectOfType<Task>();
        _slider.maxValue = _task.Counter;
        _task.CounterChanged += OnCounterChanged;
    }

    private void OnDisable()
    {
        _task.CounterChanged -= OnCounterChanged;
    }

    private void OnCounterChanged(int counter, int maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.value = counter;
    }
}
