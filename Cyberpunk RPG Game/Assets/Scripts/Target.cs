using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{

    public GameObject textOBJ;
    public TMP_Text selectedText;
    public string name;

    CharacterMovment characterMovement;

    private void Awake()
    {
        textOBJ = GameObject.Find("SelectedText");
        selectedText = textOBJ.GetComponent<TMP_Text>();
        characterMovement = this.GetComponent<CharacterMovment>();
    }

    private void OnMouseDown()
    {
        
        selectedText.text = ("Selected Character: " + name);
        characterMovement.isSelected = true;
        Debug.Log("isSelected for " + name + ": " + characterMovement.isSelected);
    }
}
