using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Interactable
{
    [SerializeField] private float _changeSpeed;
    [SerializeField] private float _maxScaleMagnitude;

    private float _delay = 0.1f;
    private float _delayAmplitude = 0.1f;

    public event Action Growed;

    private void Awake()
    {
        _delay += UnityEngine.Random.Range(-_delayAmplitude, _delayAmplitude);
    }

    public override void OnInteract()
    {
        if (transform.localScale.magnitude <= _maxScaleMagnitude)
        {
            Enlarge();

            if(transform.localScale.magnitude >= _maxScaleMagnitude)
            {
                Growed?.Invoke();
            }
        }
    }

    private void Enlarge()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one * _maxScaleMagnitude, _changeSpeed * Time.deltaTime);
    }

    public void Grow()
    {
        StartCoroutine(DelayCounter());
    }

    private IEnumerator GrowCoroutine()
    {
        while(transform.localScale.magnitude < _maxScaleMagnitude)
        {
            Enlarge();

            yield return null;
        }
    }

    private IEnumerator DelayCounter()
    {
        float timeStamp = 0;

        while (timeStamp <= _delay)
        {
            timeStamp += Time.deltaTime;

            yield return null;
        }

        StartCoroutine(GrowCoroutine());
    }
}
