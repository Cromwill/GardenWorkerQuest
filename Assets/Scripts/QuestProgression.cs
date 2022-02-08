using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestProgression : MonoBehaviour
{
    [SerializeField] private string _questSceneName;
    [SerializeField] private QuestProps _questProps;

    public bool IsComplete;

    private SaveSystem _saveSystem;

    private void Awake()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();

        if(PlayerPrefs.HasKey(_questSceneName))
            IsComplete = true;

        if (PlayerPrefs.HasKey(_questSceneName) && IsQuestProgressionActivated(_questSceneName))
        {
            _questProps.OnQuestComplete();
        }

        if (PlayerPrefs.HasKey(_questSceneName) && IsQuestProgressionActivated(_questSceneName) == false)
        {
            _questProps.OnQuestComplete();
            _saveSystem.SaveQuestProgession(_questSceneName, (int)QuestProgressionState.Activated);
        }
    }

    private bool IsQuestProgressionActivated(string questSceneName)
    {
        return PlayerPrefs.GetInt(questSceneName) == (int)QuestProgressionState.Activated;
    }
}

public enum QuestProgressionState
{
    Activated,
    Completed
}
