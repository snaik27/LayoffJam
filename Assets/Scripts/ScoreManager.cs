using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
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
}
