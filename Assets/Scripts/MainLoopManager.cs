using SidTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoopManager : MonoBehaviour
{
    public int _currentRound = 0;
    public int _totalRounds = 5;

    public enum MainLoopState
    {
        None,
        PickCard,                   //Choose card to advance
        JesterJoke,                 //Click to advance
        GuestReaction,              //Click to advance
        LoopEnd                     //Guest/King tell you if you live or not

    }

    public StateMachine<MainLoopState> _mainLoopMachine;

    private void Start()
    {
        _mainLoopMachine = new StateMachine<MainLoopState>(MainLoopState.None, machine =>
        {
            machine.ConfigureState(MainLoopState.PickCard, PickCard_Start, null, null);
            machine.ConfigureState(MainLoopState.JesterJoke, JesterJoke_Start, null, null);
            machine.ConfigureState(MainLoopState.GuestReaction, GuestReaction_Start, null, null);
            machine.ConfigureState(MainLoopState.LoopEnd, LoopEnd_Start, null, null);
        });
    }

    //Pick a random guest + traits
    //Pick 3 random cards and display
    //Per round calculate score and move to next set of cards
    public void StartMainLoop()
    {
        _currentRound = 0;
        _mainLoopMachine.SetState(MainLoopState.PickCard);
    }

    /// <summary>
    /// Pop cards off stack
    /// Show cards
    /// Anything else w visuals/audio/data
    /// </summary>
    private void PickCard_Start()
    {
        
    }

    /// <summary>
    /// pull in dialogue and display
    /// only advance on input(probably an event we fire off from dialogue system's "continue" button)
    /// </summary>
    private void JesterJoke_Start()
    {
        
    }

    /// <summary>
    /// play guest reaction/text
    /// only advance on input(same as jesterjoke)
    /// if this is the last round, move to loop end (cleanup main loop and tell GameStateManager to do outro)
    /// </summary>
    private void GuestReaction_Start()
    {
        
    }

    private void LoopEnd_Start()
    {
        GameStateManager._instance._gameStateMachine.SetState(GameStateManager.GameState.Outro);
    }
}
