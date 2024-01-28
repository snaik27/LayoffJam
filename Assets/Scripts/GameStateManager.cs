using SidTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private MusicManager _musicManager; 
    [SerializeField] private MainLoopManager _mainLoopManager;
    [SerializeField] private Deck _deck;
    [SerializeField] private Canvas _introMenu;
    [SerializeField] private Canvas _cardsAndDialogueUI;
    [SerializeField] private Transform _creditsUI;

    public static GameStateManager _instance;
    public enum GameState
    {
        Boot,
        Main, 
        Outro, 
    }

    public StateMachine<GameState> _gameStateMachine; 

    public void StartMainLoop()
    {
        _gameStateMachine.SetState(GameState.Main);
    } 

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = this;

        //Boot the things x
        //Let user switch between how to play and credits as they please x
        //On play --> Load main scene and start main loop x
        //-----let main loop happen
        //Outro w king and guests
        //play again? --> Ensure different guest
        _gameStateMachine = new StateMachine<GameState>(GameState.Boot, machine =>
        {
            machine.ConfigureState(GameState.Boot, Boot_Start, null, null);
            machine.ConfigureState(GameState.Main, Main_Start, null, null);
        });
    }

    private void Update()
    {
        _gameStateMachine.UpdateState();
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
        _deck.gameObject.SetActive(true);
        _mainLoopManager.gameObject.SetActive(true);
        _introMenu.gameObject.SetActive(true); 

        _musicManager.PlayOpeningTrack();
    }
     
    /// <summary>
    /// 
    /// </summary>
    private void Main_Start()
    {
        // main card choose/reaction loop
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        _mainLoopManager.StartMainLoop();
    } 

    private void Outro_Start()
    { 
    }
}
