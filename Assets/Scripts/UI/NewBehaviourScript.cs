using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{

    public TMP_Text _text;
    void Start()
    {
        if (PlayerPrefs.HasKey("xPosition"))
            _text.text = $"True, {PlayerPrefs.GetFloat("xPosition")}";
        else
            _text.text = "false";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
