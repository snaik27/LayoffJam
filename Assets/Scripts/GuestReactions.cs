using UnityEngine;

public class GuestReactions : MonoBehaviour
{
    public TextAsset popePositive;
    public TextAsset popeNegative;
    public TextAsset popeNeutral;

    public TextAsset ladyPositive;
    public TextAsset ladyNegative;
    public TextAsset ladyNeutral;

    public TextAsset bloodbeardPositive;
    public TextAsset bloodbeardNegative;
    public TextAsset bloodbeardNeutral;

    private ReactionSet _popeReactions;
    private ReactionSet _ladyReactions;
    private ReactionSet _bloodbeardReactions;

    public enum Reaction
    {
        Positive,
        Neutral,
        Negative
    }

    // Start is called before the first frame update
    void Start()
    {
        _bloodbeardReactions = new ReactionSet(bloodbeardNegative, bloodbeardNeutral, bloodbeardPositive);
        _ladyReactions = new ReactionSet(ladyNegative, ladyNeutral, ladyPositive);
        _popeReactions = new ReactionSet(popeNegative, popeNeutral, popePositive);
    }
     
    public string GetReactionScore(CharacterList.Character character, int score)
    {
        ReactionSet reactionSet = character switch
        {
            CharacterList.Character.BloodBeard => _bloodbeardReactions,
            CharacterList.Character.Lady => _ladyReactions,
            CharacterList.Character.Pope => _popeReactions,
            _ => throw new System.InvalidOperationException("Invalid character")
        };

        return ScoreManager.ScoreToDisposition(score) switch
        {
            Disposition.Positive => GetRandomString(reactionSet.Positive),
            Disposition.Negative => GetRandomString(reactionSet.Negative),
            Disposition.Neutral => GetRandomString(reactionSet.Neutral),
            _ => throw new System.InvalidOperationException("Invalid disposition")
        };
    }

    private string GetRandomString(string[] strings)
    {
        return strings[Random.Range(0, strings.Length)];
    }

    private class ReactionSet
    {
        public ReactionSet(TextAsset negative, TextAsset neutral, TextAsset positive)
        {
            Negative = negative.text.Split("\n");
            Neutral = neutral.text.Split("\n");
            Positive = positive.text.Split("\n");
        }

        public string[] Positive;
        public string[] Negative;
        public string[] Neutral;
    }
}
