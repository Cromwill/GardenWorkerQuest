using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GardenExitActivator : MonoBehaviour
{
    [SerializeField] private QuestPoint _questPoint;

    private LevelComplition _levelComplition;
    private Collider _collider;
    private QuestArrowCreator _arrowCreator;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _levelComplition = FindObjectOfType<LevelComplition>();
        _arrowCreator = FindObjectOfType<QuestArrowCreator>();
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
        _arrowCreator.CreatePointingArrow(_questPoint);
    }
}
