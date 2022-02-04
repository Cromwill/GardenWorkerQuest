using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneLoader : MonoBehaviour
{
    public Action LoadingScene;

    public void Load(AssetReference scene)
    {
        LoadingScene?.Invoke();
        scene.LoadSceneAsync();
    }
}
