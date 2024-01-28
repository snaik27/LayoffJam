using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// Interface for MainLoopManager to tell characters what to do
/// Set king, guest, jester from their respective objects in the main scene
/// 
/// </summary>
public class Characters : MonoBehaviour
{ 
    [HideInInspector] public CharacterList _characterList;
    public static Characters _instance;
    private void Awake()
    {
        _instance = this;
    }

    public void DoJesterNeutral() 
    {
        _characterList._jester.SetTrigger("Neutral");
    }
    public void DoJesterPhysicalJoke()
    {
        _characterList._jester.SetTrigger("Perform");
    }

    public void DoJesterVerbalJoke()
    {
        _characterList._jester.SetTrigger("Perform");
    }

    public void DoJesterPositiveReaction()
    {
        _characterList._jester.SetTrigger("Pos");
    }
    public void DoJesterNegativeReaction()
    {
        _characterList._jester.SetTrigger("Neg");
    }

    public void DoGuestPositiveReaction()
    {
        _characterList._currentGuest.SetTrigger("Pos");
    }

    public void DoGuestNeutralReaction()
    {
        _characterList._currentGuest.SetTrigger("Neutral");

    }

    public void DoGuestNegativeReaction()
    {
        _characterList._currentGuest.SetTrigger("Neg");
    }

    public void DoKingPositiveReaction()
    {
        _characterList._king.SetTrigger("Pos");
    }

    public void DoKingNeutralReaction()
    {
        _characterList._king.SetTrigger("Neutral");

    }

    public void DoKingNegativeReaction()
    {
        _characterList._king.SetTrigger("Neg");
    }
}
