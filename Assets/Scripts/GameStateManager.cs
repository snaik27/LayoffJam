using SidTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameStateManager : MonoBehaviour
{

    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private DialogueRunner _dialogueRunner;
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
        _musicManager.gameObject.SetActive(true);
        _dialogueRunner.gameObject.SetActive(true);

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
        // main card choose/reaction loop
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