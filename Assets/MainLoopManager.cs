using SidTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoopManager : MonoBehaviour
{
    public int _currentRound = 0;

    public enum MainLoopState
    {
        PickCard,

    }
 

    //Pick a random guest + traits
    //Pick 3 random cards and display
    //Per round calculate score and move to next set of cards
    public void StartMainLoop()
    {
        _currentRound = 0;
    }

}
