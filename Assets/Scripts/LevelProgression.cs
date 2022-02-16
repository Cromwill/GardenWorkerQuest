using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelProgression : MonoBehaviour
{
    private LevelsList _levelList;
    private IntegrationMetric _metric;
    private int _startTime;
    private string _firstLevelStart = "FirstLevelStart";

    public event Action<int,int> LevelCompleted;
    public event Action LevelStarted;

    private void OnEnable ()
    {
        _metric = FindObjectOfType<IntegrationMetric>();
        _levelList = FindObjectOfType<LevelsList>();

        _firstLevelStart = $"{_firstLevelStart}{SceneManager.GetActiveScene().name}";

        _levelList.LevelCompleted += OnLevelComplition;
        _levelList.LevelStarted += OnLevelStart;
    }

    private void OnDisable()
    {
        _levelList.LevelCompleted -= OnLevelComplition;
        _levelList.LevelStarted -= OnLevelStart;
    }

    private void OnLevelStart(int lvlIndex)
    {
        if (PlayerPrefs.HasKey(_firstLevelStart))
            return;

        _startTime = (int)Time.time;
        PlayerPrefs.SetInt(_firstLevelStart, _startTime);

        LevelStarted?.Invoke();
        _metric.OnLevelStart(lvlIndex);
    }

    private void OnLevelComplition(int timeWhenCompleted, int lvlIndex)
    {
        int startTime = PlayerPrefs.GetInt(_firstLevelStart);
        int timeToComplete = Mathf.Abs(timeWhenCompleted - startTime);

        LevelCompleted?.Invoke(timeToComplete, lvlIndex);
    }
}
