using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPersistence : MonoBehaviour
{

    [SerializeField] private Vector3 _positionBeforeLoading;
    [SerializeField] private SceneLoader _sceneLoader;

    private Player _player;
    private string xPosition = "xPosition";
    private string yPosition = "yPosition";
    private string zPosition = "zPosition";

    private void Start()
    {
        _player = FindObjectOfType<Player>();

        if (HasSavedPosition())
            _positionBeforeLoading = LoadPosition();

        if(_player != null)
            _player.transform.position = _positionBeforeLoading;
    }

    private void OnEnable()
    {
        _sceneLoader.LoadingScene += Save;
    }

    private void OnDisable()
    {
        _sceneLoader.LoadingScene -= Save;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(xPosition, _player.transform.position.x);
        PlayerPrefs.SetFloat(yPosition, _player.transform.position.y);
        PlayerPrefs.SetFloat(zPosition, _player.transform.position.z);
    }

    private Vector3 LoadPosition()
    {
        float xPosition = PlayerPrefs.GetFloat(this.xPosition, _player.transform.position.x);
        float yPosition = PlayerPrefs.GetFloat(this.yPosition, _player.transform.position.y);
        float zPosition = PlayerPrefs.GetFloat(this.zPosition, _player.transform.position.z);

        return new Vector3(xPosition, yPosition, zPosition);
    }

    private void DeleteSavedPosition()
    {
        PlayerPrefs.DeleteKey(xPosition);
        PlayerPrefs.DeleteKey(yPosition);
        PlayerPrefs.DeleteKey(zPosition);
    }

    private bool HasSavedPosition()
    {
        return PlayerPrefs.HasKey(xPosition);
    }
}
