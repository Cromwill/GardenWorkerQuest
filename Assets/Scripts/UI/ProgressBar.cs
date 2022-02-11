using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _changeSpeed;

    private Task _task;
    private float _currentValue;

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
        _currentValue = counter;

        StartCoroutine(ChangeCroutine());
    }

    private IEnumerator ChangeCroutine()
    {
        while(_slider.value != _currentValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _currentValue, _changeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
