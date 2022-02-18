using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialScreen;

    private string _shown = "Shown at:";
    private InputActionAdapter _input;
    private void Start()
    {
        _shown = $"{ _shown}{SceneManager.GetActiveScene().name}";
        CloseTutorial(Vector3.zero);

        if (PlayerPrefs.HasKey(_shown))
            return;

        _tutorialScreen.SetActive(true);
        PlayerPrefs.SetString(_shown, _shown);
    }

    private void OnEnable()
    {
        _input = FindObjectOfType<InputActionAdapter>();
        _input.Touched += CloseTutorial;
    }

    private void OnDisable()
    {
        _input.Touched -= CloseTutorial;
    }

    private void CloseTutorial(Vector2 position)
    {
        _tutorialScreen.SetActive(false);
    }
}

