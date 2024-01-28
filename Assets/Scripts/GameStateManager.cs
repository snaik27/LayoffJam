using SidTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] public MusicManager _musicManager; 
    [SerializeField] public MainLoopManager _mainLoopManager;
    [SerializeField] public Deck _deck;
    [SerializeField] public Guest _guest;
    [SerializeField] public Canvas _introMenu;
    [SerializeField] public CardAndDialogueUI _cardsAndDialogueUI;
    [SerializeField] public Transform _creditsUI;
    [SerializeField] public ScoreManager _scoreManager; 

    public static GameStateManager _instance;
    public enum GameState
    {
        Boot,
        Main, 
        Outro, 
    }

    public StateMachine<GameState> _gameStateMachine; 


    public void MenuPlayButton_StartMainLoop()
    {
        _gameStateMachine.SetState(GameState.Main);
    } 

    private void Start()
    {
        DontDestroyOnLoad(this);
        _instance = this;

        //Boot the things, load UI and main scene x
        //Let user switch between how to play and credits as they please x
        //On play --> Start main loop x
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
        _scoreManager.gameObject.SetActive(true);

        _musicManager.PlayOpeningTrack();


        // main card choose/reaction loop
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
    }
     
    /// <summary>
    /// 
    /// </summary>
    private void Main_Start()
    {
        _mainLoopManager.StartMainLoop();
    } 

    private void Outro_Start()
    { 
    }
}
