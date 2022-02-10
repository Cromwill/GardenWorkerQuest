using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonNextGardenLoader : MonoBehaviour
{
    private Button _button;
    private LevelsList _levelsList;
    private SaveSystem _saveSystem;
    private QuestProgression[] _questProgressions;

    private void Awake()
    {
        _levelsList = FindObjectOfType<LevelsList>();
        _saveSystem = FindObjectOfType<SaveSystem>();
        _questProgressions = FindObjectsOfType<QuestProgression>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        foreach (var quest in _questProgressions)
        {
            _saveSystem.DeleteQuestProgression(quest.QuestSceneName);
        }

        _levelsList.LoadCurrentLevel();
    }

}
