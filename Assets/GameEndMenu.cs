using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndMenu : MonoBehaviour
{
    public TextMeshProUGUI _winLossText;
    public TextMeshProUGUI _totalScore;
    public TextMeshProUGUI _buttonText;
    public void SetWinText(string text)
    {
        _winLossText.text = text;
    }
    public void SetScoreText(string text)
    { _totalScore.text = "Total Score: " + text; }

    public void SetPlayAgainButtonText(bool wonGame)
    {
        if (wonGame)
        {
            _buttonText.text = "Start the next day...";
        }
        else
        {
            _buttonText.text = "Try again in 2036!";
        }
    }
}
