using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum Trait
    {
        Dark,
        Crude,
        Silly, 
        Pun,
        Reference,
        Slapstick,
        Physical,
        Verbal
    }

    public readonly Trait Trait1;
    public readonly Trait Trait2;
    public readonly Trait Trait3;

    public readonly string Setup;
    public readonly string Punchline;

    public Card(Trait trait1, Trait trait2, Trait trait3, string setup, string punchline)
    {
        if (trait1 == trait2 || trait1 == trait3 || trait2 == trait3)
        {
            throw new ArgumentException($"No duplicate traits: {trait1}, {trait2}, {trait3}");
        }

        Trait1 = trait1;
        Trait2 = trait2;
        Trait3 = trait3;
        Setup = setup;
        Punchline = punchline;
    }

    public bool HasTrait(Trait trait)
    {
        return Trait1 == trait || Trait2 == trait || Trait3 == trait;
    }

    public override string ToString()
    {
        return $"{Trait1}\t{Trait2}\t{Trait3}\n{Setup}\n{Punchline}";
    }

    public static Trait CharToTrait(char c)
    {
        return c switch
        {
            'A' => Trait.Dark,
            'B' => Trait.Silly,
            'C' => Trait.Reference,
            'D' => Trait.Pun,
            'E' => Trait.Crude,
            'F' => Trait.Slapstick,
            _ => throw new ArgumentException($"No trait for {c}"),
        };
    }
}
