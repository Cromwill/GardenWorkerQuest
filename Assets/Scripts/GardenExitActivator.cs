using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GardenExitActivator : MonoBehaviour
{
    [SerializeField] private QuestPoint _questPoint;

    private LevelComplition _levelComplition;
    private Collider _collider;

    public event Action<QuestPoint> ExitActivated;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _levelComplition = FindObjectOfType<LevelComplition>();
        _collider.enabled = false;
        _questPoint.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _levelComplition.AllQuestsCompleted += OnAllQuestsComplited;
    }

    private void OnDisable()
    {
        _levelComplition.AllQuestsCompleted -= OnAllQuestsComplited;
    }

    private void OnAllQuestsComplited()
    {
        _collider.enabled = true;
        _questPoint.gameObject.SetActive(true);

        ExitActivated?.Invoke(_questPoint);
    }
}
