using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPersistence : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

    public Vector3 DefaultPosition = new Vector3(-56f, 0, -6.6f);
    private Player _player;
    private LevelComplition _levelComplition;
    private string _xPosition = "xPos";
    private string _yPosition = "yPos";
    private string _zPosition = "zPos";

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _levelComplition = FindObjectOfType<LevelComplition>();
        _levelComplition.AllQuestsCompleted += DeleteSavedPosition;
        _sceneLoader.LoadingScene += Save;
    }

    private void OnDisable()
    {
        _sceneLoader.LoadingScene -= Save;
        _levelComplition.AllQuestsCompleted -= DeleteSavedPosition;
    }

    private void DeleteSavedPosition()
    {
        PlayerPrefs.DeleteKey(_xPosition);
        PlayerPrefs.DeleteKey(_yPosition);
        PlayerPrefs.DeleteKey(_zPosition);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(_xPosition, _player.transform.position.x);
        PlayerPrefs.SetFloat(_yPosition, _player.transform.position.y);
        PlayerPrefs.SetFloat(_zPosition, _player.transform.position.z);
    }

    public Vector3 LoadPosition()
    {
        if (HasSavedPosition())
        {
            float xPosition = PlayerPrefs.GetFloat(_xPosition);
            float yPosition = PlayerPrefs.GetFloat(_yPosition);
            float zPosition = PlayerPrefs.GetFloat(_zPosition);

            return new Vector3(xPosition, yPosition, zPosition);
        }
        else
        {
            return DefaultPosition;
        }
    }

    public bool HasSavedPosition()
    {
        return PlayerPrefs.HasKey(_xPosition);
    }
}
