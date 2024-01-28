using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _textToDisplay;

    private void Awake()
    {
        _textToDisplay = GetComponent<TMPro.TextMeshProUGUI>(); 
    }
    public void SetText(string text)
    {
        _textToDisplay.text = text;
    }
}
