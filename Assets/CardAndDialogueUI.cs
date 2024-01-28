using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAndDialogueUI : MonoBehaviour
{
    [SerializeField] private DialogueUI _card1;
    [SerializeField] private DialogueUI _card2;
    [SerializeField] private DialogueUI _card3;
    [SerializeField] private DialogueUI _dialogueText;
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
        _card1.SetText(card1.Setup + "\n" + card1.Punchline);
        _card2.SetText(card2.Setup + "\n" + card2.Punchline);
        _card3.SetText(card3.Setup + "\n" + card3.Punchline);
    }

    public void SetDialogueText(string text)
    {
        _dialogueText.SetText(text);
    }
}

