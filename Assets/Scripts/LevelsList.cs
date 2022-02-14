using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelsList : MonoBehaviour
{
    [SerializeField] private AssetReference[] _gardenLevels;
    [SerializeField] private LevelComplition _levelComplition;
    [SerializeField] private int _levelIndexForTests;

    public int CurrentLevelIndex { get; private set; }
    public int LastLevelIndex { get; private set; }

    private string _levelKey = "level";

    public event Action<int,int> LevelCompleted;
    public event Action<int> LevelStarted;

    private void Awake()
    {
        LastLevelIndex = _gardenLevels.Length;

        if (PlayerPrefs.HasKey(_levelKey))
            CurrentLevelIndex = PlayerPrefs.GetInt(_levelKey);
        else
            CurrentLevelIndex = _levelIndexForTests;

        Invoke("StartLevel", 0.1f);
    }

    private void OnEnable()
    {
        if (_levelComplition != null)
            _levelComplition.AllQuestsCompleted += OnAllQuestsComplition;

        
    }

    private void OnDisable()
    {
        if (_levelComplition != null)
            _levelComplition.AllQuestsCompleted -= OnAllQuestsComplition;
    }

    public void LoadCurrentLevel()
    {
        _gardenLevels[CurrentLevelIndex].LoadSceneAsync();
    }

    public void StartLevel()
    {
        int lvlIndex = CurrentLevelIndex + 1;
        LevelStarted?.Invoke(lvlIndex);
    }
    
    public void SetCurrentLevel(int index)
    {
        CurrentLevelIndex = index;
    }

    private void OnAllQuestsComplition()
    {
        int CompletedTime = (int)Time.time;

        int lvlIndex = CurrentLevelIndex + 1;
        LevelCompleted?.Invoke(CompletedTime, lvlIndex);

        if (CurrentLevelIndex < _gardenLevels.Length-1)
        {
            CurrentLevelIndex++;
            PlayerPrefs.SetInt(_levelKey, CurrentLevelIndex);
        } 
        else
        {
            CurrentLevelIndex = 0;
            PlayerPrefs.SetInt(_levelKey, CurrentLevelIndex);
        }
    }
}
