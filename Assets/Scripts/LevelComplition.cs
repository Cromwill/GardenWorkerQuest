using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplition : MonoBehaviour
{
    [SerializeField] private QuestEnter _nextLevelEnter;

    private QuestProgression[] _questsProgression;
    private int _counter;

    public Action AllQuestsCompleted;

    private void Start()
    {
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
            EnableNextLevelEnter();
        }
    }

    public bool IsQuestCompleted()
    {
        return _counter <= 0;
    }

    private void EnableNextLevelEnter()
    {
        _nextLevelEnter.gameObject.SetActive(true);
    }
}
