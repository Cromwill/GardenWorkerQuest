using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private LevelComplition _levelComplition;
    [SerializeField] private Animator _animator;
    [SerializeField] private WinScreen _winScreen;

    private string LevelEnd = "LevelEnd";

    private void OnEnable()
    {
        _levelComplition.AllQuestsCompleted += Show;
    }

    private void OnDisable()
    {
        _levelComplition.AllQuestsCompleted -= Show;
    }

    private void Show()
    {
        _winScreen.gameObject.SetActive(true);
        _animator.SetTrigger(LevelEnd);
    }
}
