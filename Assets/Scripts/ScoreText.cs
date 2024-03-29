using UnityEngine;

[RequireComponent(typeof(DialogueUI))]
public class ScoreText : DialogueUI
{
    public void SetScore(int score)
    {
        Disposition disposition = ScoreManager.ScoreToDisposition(score);
        switch (disposition)
        {
            case Disposition.Positive:
                _textToDisplay.color = Color.green;
                _textToDisplay.SetText(":)");
                break;
            case Disposition.Negative:
                _textToDisplay.color = Color.red;
                _textToDisplay.SetText(":(");
                break;

            case Disposition.Neutral:
                _textToDisplay.color = Color.yellow;
                _textToDisplay.SetText(":|");
                break;
            default:
                _textToDisplay.SetText("");
                break;
        }
    }
}
