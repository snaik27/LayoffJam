using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    private TMPro.TextMeshPro _textToDisplay;

    public void SetText(string text)
    {
        _textToDisplay.text = text;
    }
}
