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
    private string _levelKey = "level";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_levelKey))
            CurrentLevelIndex = PlayerPrefs.GetInt(_levelKey);
        else
            CurrentLevelIndex = _levelIndexForTests;

        Debug.Log("hi" + CurrentLevelIndex + gameObject.name);
    }

    private void OnEnable()
    {
        if(_levelComplition != null)
            _levelComplition.AllQuestsCompleted += OnQuestsComplition;
    }

    private void OnDisable()
    {
        if (_levelComplition != null)
            _levelComplition.AllQuestsCompleted -= OnQuestsComplition;
    }

    public void LoadCurrentLevel()
    {
        _gardenLevels[CurrentLevelIndex].LoadSceneAsync();
    }
    
    public void SetCurrentLevel(int index)
    {
        CurrentLevelIndex = index;
    }

    private void OnQuestsComplition()
    {
        if (CurrentLevelIndex < _gardenLevels.Length-1)
        {
            CurrentLevelIndex++;
            PlayerPrefs.SetInt(_levelKey, CurrentLevelIndex);
        }
    }
}
