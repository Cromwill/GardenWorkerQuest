using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelsList : MonoBehaviour
{
    [SerializeField] private AssetReference[] _gardenLevels;
    [SerializeField] private LevelComplition _levelComplition;

    private int _currentLevelIndex = 0;
    private string _levelKey = "level";

    private void Awake()
    {
        if(PlayerPrefs.HasKey(_levelKey))
            _currentLevelIndex = PlayerPrefs.GetInt(_levelKey);
    }

    private void OnEnable()
    {
        _levelComplition.AllQuestsCompleted += OnQuestsComplition;
    }

    private void OnDisable()
    {
        _levelComplition.AllQuestsCompleted -= OnQuestsComplition;
    }

    private void OnQuestsComplition()
    {
        if (_currentLevelIndex < _gardenLevels.Length)
        {
            _currentLevelIndex++;
            PlayerPrefs.SetInt(_levelKey, _currentLevelIndex);
        }
    }
}
