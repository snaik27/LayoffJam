using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    const int NEUTRAL_MIN_INCLUSIVE = 0;
    const int NEUTRAL_MAX_INCLUSIVE = 0;

    public int TotalScore { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        TotalScore = 0;
    }
    
    public int ScoreRound(Guest guest, Card card)
    {
        int currentRoundScore = 0;
        currentRoundScore += (int)guest.GetDisposition(card.Trait1);
        currentRoundScore += (int)guest.GetDisposition(card.Trait2);
        currentRoundScore += (int)guest.GetDisposition(card.Trait3);

        TotalScore += currentRoundScore;
        return currentRoundScore;
    }

    public static Disposition ScoreToDisposition(int score)
    {
        if (score < NEUTRAL_MIN_INCLUSIVE)
        {
            return Disposition.Negative;
        }
        else if (score > NEUTRAL_MAX_INCLUSIVE)
        {
            return Disposition.Positive;
        }
        else
        {
            return Disposition.Neutral;
        }
    }
}
