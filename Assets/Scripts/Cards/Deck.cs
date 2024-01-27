using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public TextAsset verbalJokes;
    public TextAsset physicalJokes;

    // Start is called before the first frame update
    void Start()
    {
        // generate deck
        List<Card> cards = ReadCards();

        Debug.Log($"{cards.Count} cards");

        Debug.Log(string.Join("\n\n", cards));

    }

    // Update is called once per frame
    void Update()
    {
        
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

            Card.Trait trait1 = CharToTrait(jokeType[0]);
            Card.Trait trait2 = CharToTrait(jokeType[1]);
            cards.Add(new Card(trait1, trait2, trait, setup, punchline));
        }
    }

    private static Card.Trait CharToTrait(char c)
    {
        return c switch
        {
            'A' => Card.Trait.Dark,
            'B' => Card.Trait.Silly,
            'C' => Card.Trait.Reference,
            'D' => Card.Trait.Pun,
            'E' => Card.Trait.Crude,
            'F' => Card.Trait.Slapstick,
            _ => throw new ArgumentException($"No trait for {c}"),
        };
    }
}
