using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToGarden : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Slider _slider;

    private LevelsList _levelList;
    private void OnEnable()
    {
        StartCoroutine(WaitingForDelay());
        _slider.maxValue = _delay;
    }
    private void Start()
    {
        _levelList = FindObjectOfType<LevelsList>();
    }

    public void OnButtonClick()
    {
        _levelList.LoadCurrentLevel();
    }

    private IEnumerator WaitingForDelay()
    {
        float timePassed = 0;

        while(timePassed < _delay)
        {
            timePassed += Time.deltaTime;

            _slider.value = timePassed;

            yield return null;
        }

        _levelList.LoadCurrentLevel();
    }
}
