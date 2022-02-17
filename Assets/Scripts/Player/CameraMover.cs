using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float FOVChangeSpeed;

    private float _targetFieldOfView = 25f;
    private Camera _camera;
    private GardenExit _gardenExit;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        _gardenExit = FindObjectOfType<GardenExit>();
        _gardenExit.ExitTriggered += OnQuestsCompeted;
    }

    private void OnDisable()
    {
        _gardenExit.ExitTriggered -= OnQuestsCompeted;
    }
    private void OnValidate()
    {

    }

    private void Update()
    {
        transform.position = _player.transform.position + _offset;
    }

    private void OnQuestsCompeted()
    {
        StartCoroutine(CloseUp());
    }

    private IEnumerator CloseUp()
    {
        while(_camera.fieldOfView > _targetFieldOfView)
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _targetFieldOfView, FOVChangeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
