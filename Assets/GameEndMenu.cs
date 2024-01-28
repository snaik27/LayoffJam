using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndMenu : MonoBehaviour
{
    public TextMeshProUGUI _winLossText;
    public TextMeshProUGUI _totalScore;

    public void SetWinText(string text)
    {
        _winLossText.text = text;
    }

    public void SetScoreText(string text)
    {
        _totalScore.text = text;   
    }
}
