using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegrationMetric : MonoBehaviour
{
    private LevelsList _levelList;
    private GameLoader _gameLoader;
    private LevelProgression _levelProgression;
    private void Start()
    {
        _levelList = FindObjectOfType<LevelsList>();
    }

    private void OnEnable()
    {
        _gameLoader = FindObjectOfType<GameLoader>();

        if (_gameLoader != null)
            _gameLoader.GameStarted += OnGameStart;

        if (_levelProgression != null)
        {
            _levelProgression.LevelStarted += OnLevelStart;
            _levelProgression.LevelCompleted += OnLevelComplete;
        }
    }

    private void OnDisable()
    {
        if (_gameLoader != null)
            _gameLoader.GameStarted -= OnGameStart;

        if (_levelProgression != null)
        {
            _levelProgression.LevelStarted -= OnLevelStart;
            _levelProgression.LevelCompleted -= OnLevelComplete;
        }
    }

    private void OnGameStart(int sessionsCount)
    {
        Dictionary<string, object> count = new Dictionary<string, object>();
        count.Add("count", sessionsCount);
        Amplitude.Instance.logEvent("game_start", count);
    }

    private void OnLevelStart()
    {
        Amplitude.Instance.logEvent("level_start", CreateLevelProperty());
    }

    private void OnLevelComplete(int levelComplitioTime)
    {
        Dictionary<string, object> time_spent = new Dictionary<string, object>();
        time_spent.Add("time_spent", levelComplitioTime);

        Amplitude.Instance.logEvent("level_complete", time_spent);
        Amplitude.Instance.logEvent("level_complete", CreateLevelProperty());
    }

    private Dictionary<string, object> CreateLevelProperty()
    {
        Dictionary<string, object> level = new Dictionary<string, object>();
        int levelIndex = _levelList.CurrentLevelIndex + 1;
        level.Add("level", levelIndex);

        return level;
    }
}
