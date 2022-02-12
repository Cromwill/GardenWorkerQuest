using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    private EndScreen _endScreen;
    private int _startTime;

    public event Action LevelStarted;
    public event Action<int> LevelCompleted;
    private void Start()
    {
        _startTime = (int)Time.time;

        LevelStarted?.Invoke();
    }

    private void OnEnable()
    {
        _endScreen = FindObjectOfType<EndScreen>();
        _endScreen.Shown += OnLevelComplition;
    }

    private void OnDisable()
    {
        _endScreen.Shown -= OnLevelComplition;
    }

    private void OnLevelComplition(int timeWhenCompleted)
    {
        int timeToCompete = timeWhenCompleted - _startTime;

        LevelCompleted?.Invoke(timeToCompete);
    }
}
