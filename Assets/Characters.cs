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
    [SerializeField] public Animator _king;
    [SerializeField] public Animator _guest;
    [SerializeField] public Animator _jester;

    public static Characters _instance;
    private void Awake()
    {
        _instance = this;
    }

    public void DoJesterNeutral() { }
    public void DoJesterPhysicalJoke()
    {
        Debug.Log("IMPLEMENT VISUAL: Jester does physical joke");
    }

    public void DoJesterVerbalJoke()
    {
        Debug.Log("IMPLEMENT VISUAL: Jester does visual joke");
    }

    public void DoGuestPositiveReaction()
    {
        Debug.Log("IMPLEMENT VISUAL: Guest positive reaction");
    }

    public void DoGuestNeutralReaction()
    {

    }

    public void DoGuestNegativeReaction()
    {
        Debug.Log("IMPLEMENT VISUAL: King negative reaction");
    }

    public void DoKingPositiveReaction()
    {
        Debug.Log("IMPLEMENT VISUAL: King positive reaction");
    }

    public void DoKingNeutralReaction() { }

    public void DoKingNegativeReaction()
    {
        Debug.Log("IMPLEMENT VISUAL: King negative reaction");
    }
}
