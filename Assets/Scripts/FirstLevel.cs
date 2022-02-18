using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    private string _levelKey = "level";
    private void Awake()
    {
        PlayerPrefs.SetInt(_levelKey, 0);
    }
}
