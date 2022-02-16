using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class BreakableCleaner : MonoBehaviour
{
    private Quest _quest;
    private Breakable[] _breakables;

    private void OnEnable()
    {
        _quest = FindObjectOfType<Quest>();
        _breakables = FindObjectsOfType<Breakable>();
        _quest.Completed += DestroyAll;
    }

    private void OnDisable()
    {
        _quest.Completed -= DestroyAll;
    }

    private void DestroyAll()
    {
        for (int i = 0; i < _breakables.Length; i++)
        {
            if (_breakables[i] != null)
                _breakables[i].GetComponent<RayfireRigid>().Activate();
        }
    }
}
