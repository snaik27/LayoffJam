using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestReactions : MonoBehaviour
{
    public TextAsset positive;
    public TextAsset negative;
    public TextAsset neutral;

    private string[] _positiveReactions;
    private string[] _negativeReactions;
    private string[] _neutralReactions;

    // Start is called before the first frame update
    void Start()
    {
        _positiveReactions = positive.text.Split("\n");
        _negativeReactions = negative.text.Split("\n");
        _neutralReactions = neutral.text.Split("\n");
    }

    public string GetReaction(Guest.Disposition disposition)
    {
        return disposition switch
        {
            Guest.Disposition.Negative => GetNegativeReaction(),
            Guest.Disposition.Positive => GetPositiveReaction(),
            Guest.Disposition.Neutral => GetNeutralReaction(),
            _ => throw new System.InvalidOperationException($"{disposition} is not a valid disposition"),
        };
    }

    public string GetPositiveReaction()
    {
        return GetRandomString(_positiveReactions);
    }
    public string GetNegativeReaction()
    {
        return GetRandomString(_negativeReactions);
    }

    public string GetNeutralReaction()
    {
        return GetRandomString(_neutralReactions);
    }

    private string GetRandomString(string[] strings)
    {
        return strings[Random.Range(0, strings.Length)];
    }
}
