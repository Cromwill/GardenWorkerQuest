using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    [SerializeField] private List<Task> _tasks;
    [SerializeField] private float _customDelay;

    private float _delay = 0.8f;
    private string _name;
    private SaveSystem _saveSystem;
    private int _taskCounter;

    public Action Completed;

    private void Awake()
    {
        if (_customDelay != 0)
            _delay = _customDelay;

        _name = SceneManager.GetActiveScene().name;
        _saveSystem = FindObjectOfType<SaveSystem>();
        _taskCounter = _tasks.Count;
    }

    private void OnEnable()
    {
        foreach (var task in _tasks)
        {
            task.Complete += TryComplete;
        }
    }

    private void OnDisable()
    {
        foreach (var task in _tasks)
        {
            task.Complete -= TryComplete;
        }
    }

    public void TryComplete()
    {
        _taskCounter--;

        if (IsCompleted())
        {
            Debug.Log("win");
            _saveSystem.SaveQuestProgession(_name, (int)QuestProgressionState.Completed);
            StartCoroutine(WaitingForDelayBeforComplete());
        }
    }

    private IEnumerator WaitingForDelayBeforComplete()
    {
        float timePassed = 0;

        while(timePassed <_delay)
        {
            timePassed += Time.deltaTime;

            yield return null;
        }

        Completed?.Invoke();
    }

    private bool IsCompleted()
    {
        return _taskCounter<=0;
    }
}
