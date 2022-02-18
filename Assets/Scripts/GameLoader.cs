using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private LevelsList _leveList;

    private string _sessionCountName = "SessionCount";
    private int _sessionsCount = 0;

    public event Action<int> GameStarted;

    private void Awake()
    {
        Amplitude amplitude = Amplitude.Instance;
        amplitude.logging = true;
        amplitude.init("c4d2e95fea6a747a1b92ed2d50b8be0c");
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_sessionCountName))
        {
            _sessionsCount = PlayerPrefs.GetInt(_sessionCountName);
            _sessionsCount++;
        }

        PlayerPrefs.SetInt(_sessionCountName, _sessionsCount);

        GameStarted?.Invoke(_sessionsCount);


        _leveList.LoadCurrentLevel();
    }
}
