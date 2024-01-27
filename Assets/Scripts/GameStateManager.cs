using SidTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    [SerializeField] private MusicManager _musicManager;

    public enum GameState
    {
        Boot,
        Intro,
        Main,
        Outro,
        Credits
    }


    public StateMachine<GameState> _gameStateMachine;



    private void Start()
    {
        _gameStateMachine = new StateMachine<GameState>(GameState.Boot, machine =>
        {
            machine.ConfigureState(GameState.Boot, Boot_Start, null, null);
            machine.ConfigureState(GameState.Intro, Intro_Start, null, null);
            machine.ConfigureState(GameState.Main, Main_Start, null, null);
            machine.ConfigureState(GameState.Outro, Outro_Start, null, null);
            machine.ConfigureState(GameState.Credits, Credits_Start, null, null);
        });
    }

    /// <summary>
    /// Load all the things:
    /// 1. Music/SFX
    /// 2. Dialogue
    /// 3. Menu
    /// </summary>
    private void Boot_Start()
    {
        _musicManager.PlayOpeningTrack();
    }

    /// <summary>
    /// Start intro tutorial
    /// </summary>
    private void Intro_Start()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    private void Main_Start()
    {

    }

    private void Outro_Start()
    {

    }

    private void Credits_Start()
    {

    }

    private void Update()
    {
        _gameStateMachine.UpdateState();
    }
}
