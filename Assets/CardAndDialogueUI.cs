using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAndDialogueUI : MonoBehaviour
{
    [SerializeField] private DialogueUI _card1;
    [SerializeField] private DialogueUI _card2;
    [SerializeField] private DialogueUI _card3;
    [SerializeField] private DialogueUI _dialogueText;
    [SerializeField] private ScoreText _scoreText;
    [SerializeField] private DialogueUI _speakerText;
    [SerializeField] private GameObject _dialogueObject;
    [SerializeField] private GameObject _cardObject;

    private void Start()
    {
        _dialogueObject.SetActive(false);
    }
    public void DisplayCardsAndHideDialogue()
    {
        _cardObject.SetActive(true);
        _dialogueObject.SetActive(false);

        _card1.gameObject.SetActive(true);
        _card2.gameObject.SetActive(true);
        _card3.gameObject.SetActive(true);
        _dialogueText.gameObject.SetActive(false);
        _scoreText.gameObject.SetActive(false);
        
    }

    public void DisplayDialogueAndHideCards()
    {
        _dialogueObject.SetActive(true);
        _cardObject.SetActive(false);

        _card1.gameObject.SetActive(false);
        _card2.gameObject.SetActive(false);
        _card3.gameObject.SetActive(false);
        _dialogueText.gameObject.SetActive(true);
    }

    public void SetCards(Card card1, Card card2, Card card3)
    {
        _card1.SetText(card1.DisplayString());
        _card2.SetText(card2.DisplayString());
        _card3.SetText(card3.DisplayString());
    }

    public void SetCurrentRoundScore(int score)
    {
        _scoreText.gameObject.SetActive(true);
        _scoreText.SetScore(score);
    }

    public void SetDialogueText(string speaker, string text)
    {
        _speakerText.SetText(speaker);
        _dialogueText.SetText(text);
    }
} 