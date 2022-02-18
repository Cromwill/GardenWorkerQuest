using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(QuestEnter))]
public class NamePresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private QuestEnter _quest;
    private Canvas _canvas;

    private void Start()
    {
        //_quest = GetComponent<QuestEnter>();
        //_text = GetComponentInChildren<TMP_Text>();
        //_canvas = GetComponentInChildren<Canvas>();
        //_canvas.worldCamera = Camera.main;
        //_text.text = _quest.Name;
    }
}
