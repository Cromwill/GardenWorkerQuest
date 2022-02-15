using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private float yOffset;
    [SerializeField] private Slider _slider;

    private float _changeSpeed;
    private Player _player;
    private IQuestLoader _questEnter;
    private Coroutine _coroutine;
    private void Start()
    {
        _changeSpeed = 1.3f;
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        Vector3 position = new Vector3(_player.transform.position.x, _player.transform.position.y + yOffset, _player.transform.position.z);

        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IQuestLoader questEnter))
        {
            _questEnter = questEnter;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(FillingUp());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IQuestLoader questEnter))
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(FillingDown());
        }
    }

    private IEnumerator FillingUp()
    {
        while(_slider.value < _slider.maxValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _slider.maxValue, _changeSpeed * Time.deltaTime);

            yield return null;
        }

        _questEnter.LoadQuestScene();
    }

    private IEnumerator FillingDown()
    {
        while (_slider.value > _slider.minValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _slider.minValue, _changeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
