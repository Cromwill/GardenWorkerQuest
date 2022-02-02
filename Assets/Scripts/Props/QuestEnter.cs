using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class QuestEnter : Interactable
{
    [SerializeField] private AssetReference _scene;

    public string Name;

    public override void OnInteract()
    {
        _scene.LoadSceneAsync();
    }
}
