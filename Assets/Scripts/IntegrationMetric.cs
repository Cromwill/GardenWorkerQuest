using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegrationMetric : MonoBehaviour
{
    private GameLoader _gameLoader;
    private LevelProgression _levelProgression;

    private void OnEnable()
    {
        _gameLoader = FindObjectOfType<GameLoader>();
        _levelProgression = FindObjectOfType<LevelProgression>();

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

    public void OnLevelStart(int levelIndex)
    {
        Dictionary<string, object> level = new Dictionary<string, object>();
        level.Add("level", levelIndex);

        Amplitude.Instance.logEvent("level_start", level);
    }

    private void OnLevelComplete(int levelComplitioTime, int levelIndex)
    {
        Dictionary<string, object> time_spent = new Dictionary<string, object>();
        time_spent.Add("time_spent", levelComplitioTime);

        Amplitude.Instance.logEvent("level_complete", time_spent);

        Dictionary<string, object> level = new Dictionary<string, object>();
        level.Add("level", levelIndex);

        Amplitude.Instance.logEvent("level_complete", level);
    }

    private Dictionary<string, object> CreateLevelProperty(int levelIndex)
    {
        Dictionary<string, object> level = new Dictionary<string, object>();
        level.Add("level", levelIndex);

        return level;
    }
}
