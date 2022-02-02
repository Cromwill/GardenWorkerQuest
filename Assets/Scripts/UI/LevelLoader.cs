using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private AssetReference _scene;

    public Action LoadingLevel;

    public void Load()
    {
        LoadingLevel?.Invoke();
        _scene.LoadSceneAsync();
    }
}
