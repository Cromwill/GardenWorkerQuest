using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenActivator : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private float _customDelay;

    private float _delay = 0.8f;

    private Quest _quest;

    private void Start()
    {
        if (_customDelay != 0)
            _delay = _customDelay;
        _winScreen.SetActive(false);
    }
    private void OnEnable()
    {
        _quest = FindObjectOfType<Quest>();
        _quest.Completed += Activate;
    }

    private void OnDisable()
    {
        _quest.Completed -= Activate;
    }

    private void Activate()
    {
        StartCoroutine(WaitingForDelayBeforeActivate());
    }

    private IEnumerator WaitingForDelayBeforeActivate()
    {
        float timePassed = 0;

        while (timePassed < _delay)
        {
            timePassed += Time.deltaTime;

            yield return null;
        }

        _winScreen.SetActive(true);
    }
}
