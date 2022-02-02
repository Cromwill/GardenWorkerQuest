using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class QuestEnter : Interactable
{
    [SerializeField] private AssetReference _scene;

    public string Name;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public override void OnInteract()
    {
        _sceneLoader.Load(_scene);
    }
}
