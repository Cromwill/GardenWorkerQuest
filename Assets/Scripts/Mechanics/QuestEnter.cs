using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class QuestEnter : Interactable, IQuestLoader
{
    [SerializeField] private AssetReference _scene;

    public string Name;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void LoadQuestScene()
    {
        _sceneLoader.Load(_scene);
    }
}
