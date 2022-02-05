using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Interactable
{
    [SerializeField] private float _changeSpeed;

    private float _maxScaleMagnitude = 2f;
    private float _delay = 0.2f;
    private float _delayAmplitude = 0.1f;

    private void Awake()
    {
        _delay += Random.Range(-_delayAmplitude, _delayAmplitude);
    }

    public override void OnInteract()
    {
        if(transform.localScale.magnitude<= _maxScaleMagnitude)
            transform.localScale += new Vector3(_changeSpeed, _changeSpeed, _changeSpeed);
    }

    public void Grow()
    {
        StartCoroutine(DelayCounter());
    }

    private IEnumerator GrowCoroutine()
    {
        while(transform.localScale.magnitude < _maxScaleMagnitude)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one * _maxScaleMagnitude, _changeSpeed);

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
