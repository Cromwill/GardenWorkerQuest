using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ButtonLevelLoader : MonoBehaviour
{
    [SerializeField] private AssetReference _scene;
    [SerializeField] private SceneLoader _sceneLoader;

    public void Load()
    {
        _sceneLoader.Load(_scene);
    }
}
