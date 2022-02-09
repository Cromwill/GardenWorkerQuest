using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestProps : MonoBehaviour
{
    [SerializeField] private Prop[] _props;

    public void OnQuestComplete()
    {
        foreach (var prop in _props)
        {
            ChangeState(prop);
        }
    }

    private void ChangeState(Prop prop)
    {
        prop.IsActive = !prop.IsActive;

        prop.gameObject.SetActive(prop.IsActive);

    }
}
