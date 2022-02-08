using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    [SerializeField] private string _questSceneName;
    [SerializeField] private QuestProps _questProps;

    private SaveSystem _saveSystem;

    private void Start()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();

        if(PlayerPrefs.HasKey(_questSceneName) && IsQuestProgressionActivated(_questSceneName))
            _questProps.OnQuestComplete();

        if (PlayerPrefs.HasKey(_questSceneName) && IsQuestProgressionActivated(_questSceneName) == false)
        {
            _questProps.OnQuestComplete();
            _saveSystem.SaveQuestProgession(_questSceneName, (int)QuestProgression.Activated);
        } 
    }

    private bool IsQuestProgressionActivated(string questSceneName)
    {
        return PlayerPrefs.GetInt(questSceneName) == (int)QuestProgression.Activated;
    }
}

public enum QuestProgression
{
    Activated,
    Completed
}
