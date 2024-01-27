using System;

public class Card
{
    public enum Trait
    {
        Dark = 'A',
        Silly = 'B',
        Reference = 'C',
        Pun = 'D',
        Crude = 'E',
        Slapstick = 'F',
        Physical = 'Y',
        Verbal = 'Z'
    }

    public readonly Trait Trait1;
    public readonly Trait Trait2;
    public readonly Trait Trait3;
    
    public readonly string Setup;
    public readonly string Punchline;

    public Card(Trait trait1, Trait trait2, Trait trait3, string setup, string punchline)
    {
        if (trait1 == trait2)
        {
            throw new ArgumentException($"No duplicate traits: {trait1}, {trait2}");
        }
        if (trait3 != Trait.Physical && trait3 != Trait.Verbal)
        {
            throw new ArgumentException("Trait3 needs to be Physical or Verbal");
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

    public string GetTraitString()
    {
        return $"{(char)Trait1}{(char)Trait2}{(char)Trait3}";
    }

    public override string ToString()
    {
        return $"[{Trait1},{Trait2},{Trait3}] {Setup}; {Punchline}";
    }
}
