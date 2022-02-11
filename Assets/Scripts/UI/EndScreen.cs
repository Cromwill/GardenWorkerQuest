using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private LevelComplition _levelComplition;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private TMP_Text _text;

    private GardenExit _gardenExit;
    private string LevelEnd = "LevelEnd";
    private LevelsList _levelList;
    private JoystickCanvas _joyStickCanvas;

    private void Start()
    {
        _winScreen.SetActive(false);

    }
    private void OnEnable()
    {
        _levelList = FindObjectOfType<LevelsList>();
        _joyStickCanvas = FindObjectOfType<JoystickCanvas>();
        _gardenExit = FindObjectOfType<GardenExit>();

        _gardenExit.ExitTriggered += Show;
        //_levelComplition.AllQuestsCompleted += Show;

        int levelIndex = _levelList.CurrentLevelIndex + 1;
        _text.text = $" Level {levelIndex} completed!";
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
        _animator.SetTrigger(LevelEnd);
    }
}
