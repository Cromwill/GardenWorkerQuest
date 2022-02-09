using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private LevelsList _leveList;

    private void Start()
    {
        _leveList.LoadCurrentLevel();
    }
}
