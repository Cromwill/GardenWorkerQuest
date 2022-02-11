using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private LevelsList _levelList;
    private void OnEnable()
    {
        _levelList = FindObjectOfType<LevelsList>();
        int levelIndex = _levelList.CurrentLevelIndex;
        _text.text = $" Level {levelIndex} completed!";
    }
}
