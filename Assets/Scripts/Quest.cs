using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private List<Task> _tasks;

    private int _taskCounter;

    public Action Completed;

    private void Awake()
    {
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
            Completed?.Invoke();
        }
    }

    private bool IsCompleted()
    {
        return _taskCounter<=0;
    }
}
