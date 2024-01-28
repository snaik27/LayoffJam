using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Guest : MonoBehaviour
{
    public enum Disposition
    {
        Positive = 2,
        Neutral = 1,
        Negative = -2
    }

    private Disposition[] _dispositions;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDispositions();
        int score = 0;
    }

    public Disposition GetDisposition(Card.Trait trait)
    {
        return _dispositions[(int)trait];
    }

    private void GenerateDispositions()
    {
        List<Card.Trait> traits = Enum.GetValues(typeof(Card.Trait)).Cast<Card.Trait>().ToList();
        _dispositions = new Disposition[traits.Count];
        Array.Fill(_dispositions, Disposition.Neutral);

        bool likesPhysical = Random.Range(0, 2) == 1;
        _dispositions[(int)Card.Trait.Physical] = likesPhysical ? Disposition.Positive : Disposition.Negative;
        _dispositions[(int)Card.Trait.Verbal] = likesPhysical ? Disposition.Negative : Disposition.Positive;

        // already have dispostions for these, remove them
        traits.Remove(Card.Trait.Physical);
        traits.Remove(Card.Trait.Verbal);

        // Get 1 extra trait for each disposition
        foreach (Disposition disposition in Enum.GetValues(typeof(Disposition)))
        {
            // get a random trait and remove it from consideration
            int randomIndex = Random.Range(0, traits.Count);
            Card.Trait trait = traits[randomIndex];
            traits.RemoveAt(randomIndex);

            // map the random trait to the dispositon
            _dispositions[(int)trait] = disposition;
        }
    }
}
