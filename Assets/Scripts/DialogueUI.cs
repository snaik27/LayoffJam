using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] protected TMPro.TextMeshProUGUI _textToDisplay;

    protected void Awake()
    {
        _textToDisplay = GetComponent<TMPro.TextMeshProUGUI>(); 
    }
    public void SetText(string text)
    {
        _textToDisplay.text = text;
    }
}
