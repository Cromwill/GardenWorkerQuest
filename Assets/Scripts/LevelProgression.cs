using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    private LevelsList _levelList;
    private int _startTime;
    private string _firstLevelStart = "FirstLevelStart";
    private int _currentLevel;

    public event Action<int> LevelStarted;
    public event Action<int,int> LevelCompleted;

    private void Awake()
    {
        _levelList = FindObjectOfType<LevelsList>();

        _currentLevel = _levelList.CurrentLevelIndex +1;
        Debug.Log("level: " + _currentLevel);

        _firstLevelStart = $"{_firstLevelStart}{SceneManager.GetActiveScene().name}";


        if (PlayerPrefs.HasKey(_firstLevelStart))
            return;

        _startTime = (int)Time.time;
        PlayerPrefs.SetInt(_firstLevelStart, _startTime);
        LevelStarted?.Invoke(_currentLevel);
    }

    private void OnEnable()
    {
        _levelList.LevelCompleted += OnLevelComplition;
    }

    private void OnDisable()
    {
        _levelList.LevelCompleted -= OnLevelComplition;
    }

    private void OnLevelComplition(int timeWhenCompleted)
    {
        int startTime = PlayerPrefs.GetInt(_firstLevelStart);
        int timeToComplete = Mathf.Abs(timeWhenCompleted - startTime);

        LevelCompleted?.Invoke(timeToComplete, _currentLevel);
    }
}
