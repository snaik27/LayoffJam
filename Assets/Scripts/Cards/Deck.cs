using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public TextAsset verbalJokes;
    public TextAsset physicalJokes;

    private List<Card> _cards;
    private List<Card> _discard; 

    /// <summary>
    /// Called at start of each main loop
    /// </summary>
    public void CreateRandomDeck()
    {
        _cards = ReadCards();
        _discard = new List<Card>();
        Shuffle();
        Debug.Log(string.Join("\n", _cards));
    }

    /// <summary>
    /// Called at start of each round of main loop
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.InvalidOperationException"></exception>
    public Card[] DrawCards()
    {
        if (_cards.Count < 3)
        {
            throw new System.InvalidOperationException("You need at least 3 cards!");
        }

        Shuffle();
        return new Card[] { _cards[0], _cards[1], _cards[2] };
    }

    /// <summary>
    /// Call after using a card
    /// </summary>
    /// <param name="card"></param>
    public void Discard(Card card)
    {
        _cards.Remove(card);
        _discard.Add(card);
    }

    private void Shuffle()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            int swapIdx = Random.Range(0, _cards.Count);
            (_cards[i], _cards[swapIdx]) = (_cards[swapIdx], _cards[i]);
        }
    }

    private List<Card> ReadCards()
    {
        List<Card> cards = new List<Card>();

        LoadJokesFromTextAsset(verbalJokes, cards, Card.Trait.Verbal);
        LoadJokesFromTextAsset(physicalJokes, cards, Card.Trait.Physical);

        return cards;
    }

    private static void LoadJokesFromTextAsset(TextAsset textAsset, List<Card> cards, Card.Trait trait)
    {
        string[] lines = textAsset.text.Split("\n");
        foreach (string line in lines)
        {
            string[] parts = line.Split(" - ");
            string jokeType = parts[0].Trim();
            parts = parts[1].Split(" // ");
            string setup = parts[0].Trim();
            string punchline = parts[1].Trim();

            Card.Trait trait1 = Card.CharToTrait(jokeType[0]);
            Card.Trait trait2 = Card.CharToTrait(jokeType[1]);
            cards.Add(new Card(trait1, trait2, trait, setup, punchline));
        }
    }
}
