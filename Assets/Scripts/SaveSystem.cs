using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveSystem : MonoBehaviour
{
    public void SaveQuestProgession(string keyName, int questState)
    {
        PlayerPrefs.SetInt(keyName, questState);
    }

    public int LoadQuestProgression(string keyName)
    {
        return PlayerPrefs.GetInt(keyName);
    }

    public void DeleteProgession()
    {
        PlayerPrefs.DeleteAll();
    }
}
