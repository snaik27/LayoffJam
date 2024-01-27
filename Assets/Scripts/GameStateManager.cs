using SidTools;
using UnityEngine;


public class GameStateManager : MonoBehaviour
{
    [SerializeField] private MusicManager _musicManager; 
    [SerializeField] private MainLoopManager _mainLoopManager;

    public static GameStateManager _instance;
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
        _instance = this;
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
        _mainLoopManager.gameObject.SetActive(true);

        _musicManager.PlayOpeningTrack();
    }

    /// <summary>
    /// Start intro tutorial
    /// </summary>
    private void Intro_Start()
    {
        _gameStateMachine.SetState(GameState.Main);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Main_Start()
    {
        // main card choose/reaction loop
        _mainLoopManager.StartMainLoop();
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
