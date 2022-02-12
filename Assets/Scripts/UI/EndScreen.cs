using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _winScreen;

    private GardenExit _gardenExit;
    private string LevelEnd = "LevelEnd";
    private JoystickCanvas _joyStickCanvas;

    public event Action<int> Shown;

    private void Start()
    {
        _winScreen.SetActive(false);
    }
    private void OnEnable()
    {
        _joyStickCanvas = FindObjectOfType<JoystickCanvas>();
        _gardenExit = FindObjectOfType<GardenExit>();

        _gardenExit.ExitTriggered += Show;
        //_levelComplition.AllQuestsCompleted += Show;
    }

    private void OnDisable()
    {
        _gardenExit.ExitTriggered -= Show;
        //_levelComplition.AllQuestsCompleted -= Show;
    }

    private void Show()
    {
        _winScreen.gameObject.SetActive(true);
        _joyStickCanvas.gameObject.SetActive(false);

        int ShownTime = (int)Time.time;
        Shown?.Invoke(ShownTime);

        _animator.SetTrigger(LevelEnd);
    }
}
