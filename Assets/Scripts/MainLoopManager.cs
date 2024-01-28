using SidTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoopManager : MonoBehaviour
{

    [SerializeField] private int _currentRound = 0;
    [SerializeField] private int _totalRounds = 4;

    private Deck _cardDeck;
    private Guest _currentGuest;
    private CardAndDialogueUI _cardAndDialogueUI;
    private ScoreManager _scoreManager;
    private Card[] _currentHand;
    private Card _chosenCard;
    private Characters _characters;
    public enum MainLoopState
    { 
        None,
        PickCard,                   //Choose card to advance
        JesterJokeSetup,                 //Click to advance
        JesterJokePunchline,        //Click to advance
        GuestReaction,              //Click to advance
        LoopEnd                     //Guest/King tell you if you live or not
    }

    public StateMachine<MainLoopState> _mainLoopMachine;


    public void CardUI_PlayCard(int index)
    {
        Debug.Log(_currentHand[index].Setup);
        _chosenCard = _currentHand[index];
        _mainLoopMachine.SetState(MainLoopState.JesterJokeSetup);
    }

    public void DialogueUI_AdvanceText()
    {
        if(_mainLoopMachine.CurrentState == MainLoopState.JesterJokeSetup)
        {
            _mainLoopMachine.SetState(MainLoopState.JesterJokePunchline);
        }
        else if(_mainLoopMachine.CurrentState == MainLoopState.JesterJokePunchline)
        {
            _mainLoopMachine.SetState(MainLoopState.GuestReaction);
        }
        else if(_mainLoopMachine.CurrentState == MainLoopState.GuestReaction)
        {
            _mainLoopMachine.SetState(MainLoopState.PickCard);
        }
        else if(_mainLoopMachine.CurrentState == MainLoopState.LoopEnd)
        { 
            GameStateManager._instance._gameStateMachine.SetState(GameStateManager.GameState.Outro);
            _cardAndDialogueUI.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        _cardDeck =                 GameStateManager._instance._deck;
        _currentGuest =             GameStateManager._instance._guest;
        _cardAndDialogueUI =        GameStateManager._instance._cardsAndDialogueUI;
        _scoreManager =             GameStateManager._instance._scoreManager;
        _characters = GameStateManager._instance._characters;
        // Choose guest --> Guest script generates new guest on awake, just refer to that when needed
        // Show Card UI
        // Get 3 cards
        // User chooses card
        // Display setup dialogue
        // Click to advance
        // Display punchline dialogue
        // Click to advance
        // Display guest reaction + affect score
        // redo till total_rounds
        // leave loop
        _mainLoopMachine = new StateMachine<MainLoopState>(MainLoopState.None, machine =>
        {
            machine.ConfigureState(MainLoopState.PickCard, PickCard_Start, null, null);
            machine.ConfigureState(MainLoopState.JesterJokeSetup, JesterJokeSetup_Start, null, null);
            machine.ConfigureState(MainLoopState.JesterJokePunchline, JesterJokePunchline_Start, null, null);
            machine.ConfigureState(MainLoopState.GuestReaction, GuestReaction_Start, null, null);
            machine.ConfigureState(MainLoopState.LoopEnd, LoopEnd_Start, null, null);
        });
    }

    //Pick a random guest + traits
    //Create a new deck
    //Set round and score to zero
    public void StartMainLoop()
    {
        _currentRound = 0;
        _cardDeck.CreateRandomDeck();
        _currentGuest.GenerateRandomGuest();
        _characters._characterList.NextCharacter();
        _currentGuest.Name = _characters._characterList._currentCharacter.ToString();
        _cardAndDialogueUI.gameObject.SetActive(true);

        _mainLoopMachine.SetState(MainLoopState.PickCard);
    }

    /// <summary>
    /// Pop cards off stack
    /// Show cards
    /// Anything else w visuals/audio/data 
    /// </summary>
    private void PickCard_Start()
    {
        Card[] newHand = _cardDeck.DrawCards();
        _currentHand = newHand;

        _cardAndDialogueUI.DisplayCardsAndHideDialogue();
        _cardAndDialogueUI.SetCards(newHand[0], newHand[1], newHand[2]);


        _characters.DoKingNeutralReaction();
        _characters.DoGuestNeutralReaction();
    }

    /// <summary>
    /// pull in dialogue and display
    /// only advance on input(probably an event we fire off from dialogue system's "continue" button)
    /// </summary>
    private void JesterJokeSetup_Start()
    {
        _cardAndDialogueUI.DisplayDialogueAndHideCards();
        _cardAndDialogueUI.SetDialogueText("Joker", _chosenCard.Setup);

        if (_chosenCard.Trait3 == Card.Trait.Physical)
        {
            _characters.DoJesterPhysicalJoke();
        }
        else
        {
            _characters.DoJesterVerbalJoke();
        }
    }
    /// <summary>
    /// show punchline
    /// click to advance
    /// </summary>
    private void JesterJokePunchline_Start() 
    {
        _cardAndDialogueUI.SetDialogueText("Joker", _chosenCard.Punchline);
        _characters.DoJesterNeutral();    
    }

    
    /// <summary>
    /// play guest reaction/text
    /// only advance on input(same as jesterjoke)
    /// if this is the last round, move to loop end (cleanup main loop and tell GameStateManager to do outro)
    /// </summary>
    private void GuestReaction_Start()
    {

        int currentRoundScore = _scoreManager.ScoreRound(_currentGuest, _chosenCard);
        string guestReaction = _currentGuest.GetGuestReactionScore(currentRoundScore);
        Disposition guestDisposition = ScoreManager.ScoreToDisposition(currentRoundScore);
        switch (guestDisposition)
        {
            case Disposition.Positive:
                _characters.DoKingPositiveReaction();
                _characters.DoGuestPositiveReaction();
                break;
            case Disposition.Neutral:
                _characters.DoKingNeutralReaction();
                _characters.DoGuestNeutralReaction();
                break;
            case Disposition.Negative:
                _characters.DoKingNegativeReaction();
                _characters.DoGuestNegativeReaction();
                break; 
        }

        _cardAndDialogueUI.SetCurrentRoundScore(currentRoundScore);
        _cardAndDialogueUI.SetDialogueText(_currentGuest.Name, guestReaction);
        if (_currentRound < _totalRounds)
        {
            _currentRound++;
        }
        else
        {
            _mainLoopMachine.SetState(MainLoopState.LoopEnd);
        } 
    }

    private void LoopEnd_Start()
    {
        Debug.Log("got to loop end");
    }
} 