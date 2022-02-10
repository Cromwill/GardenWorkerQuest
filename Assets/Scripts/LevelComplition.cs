using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplition : MonoBehaviour
{
    private QuestProgression[] _questsProgression;
    private int _counter;

    public Action AllQuestsCompleted;

    private void Start()
    {

        Debug.Log(gameObject.name);
        _questsProgression = FindObjectsOfType<QuestProgression>();

        _counter = _questsProgression.Length;

        foreach (var qusetProgression in _questsProgression)
        {
            if (qusetProgression.IsComplete)
            {
                _counter--;
            }
        }

        if (IsQuestCompleted())
        {
            AllQuestsCompleted?.Invoke();
        }
    }

    public bool IsQuestCompleted()
    {
        return _counter <= 0;
    }
}
