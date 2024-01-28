using UnityEngine;

[RequireComponent(typeof(DialogueUI))]
public class ScoreText : DialogueUI
{
    public void SetScore(int score)
    {
        Disposition disposition = ScoreManager.ScoreToDisposition(score);

        string scoreText = score > 0 ? "+" : "";
        scoreText += $"{score}";
        SetText(scoreText);
        _textToDisplay.color = disposition switch
        {
            Disposition.Positive => Color.green,
            Disposition.Negative => Color.red,
            Disposition.Neutral => Color.yellow,
            _ => Color.black
        };
    }
}
