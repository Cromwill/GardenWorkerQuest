using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GardenExitActivator : MonoBehaviour
{
    [SerializeField] private GameObject _exitView;

    private LevelComplition _levelComplition;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _levelComplition = FindObjectOfType<LevelComplition>();
        _collider.enabled = false;
        _exitView.SetActive(false);
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
        _exitView.SetActive(true);
    }
}
