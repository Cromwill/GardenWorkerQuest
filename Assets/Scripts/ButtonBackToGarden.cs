using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackToGarden : MonoBehaviour
{
    private LevelsList _levelList;

    private void Start()
    {
        _levelList = FindObjectOfType<LevelsList>();
    }

    public void OnButtonClick()
    {
        _levelList.LoadCurrentLevel();
    }
}
