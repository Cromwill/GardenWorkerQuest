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

    private void Awake()
    {
        LastLevelIndex = _gardenLevels.Length;

        if (PlayerPrefs.HasKey(_levelKey))
            CurrentLevelIndex = PlayerPrefs.GetInt(_levelKey);
        else
            CurrentLevelIndex = _levelIndexForTests;
    }

    private void OnEnable()
    {
        if(_levelComplition != null)
            _levelComplition.AllQuestsCompleted += OnAllQuestsComplition;
    }

    private void OnDisable()
    {
        if (_levelComplition != null)
            _levelComplition.AllQuestsCompleted -= OnAllQuestsComplition;
    }

    public void LoadCurrentLevel()
    {
        Debug.Log(CurrentLevelIndex);
        _gardenLevels[CurrentLevelIndex].LoadSceneAsync();
    }

    public void LoadRandomLevel()
    {
        int index = Random.Range(0, _gardenLevels.Length);

        _gardenLevels[index].LoadSceneAsync();
    }
    
    public void SetCurrentLevel(int index)
    {
        CurrentLevelIndex = index;
    }

    private void OnAllQuestsComplition()
    {
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
