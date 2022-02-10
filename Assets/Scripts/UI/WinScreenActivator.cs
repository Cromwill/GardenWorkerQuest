using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenActivator : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    
    private Quest _quest;

    private void Start()
    {
        _winScreen.SetActive(false);
    }
    private void OnEnable()
    {
        _quest = FindObjectOfType<Quest>();
        _quest.Completed += Activate;
    }

    private void OnDisable()
    {
        _quest.Completed -= Activate;
    }

    private void Activate()
    {
        _winScreen.SetActive(true);
    }
}
