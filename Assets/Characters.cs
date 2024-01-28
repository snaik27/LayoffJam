using UnityEngine;

/// <summary>
/// Interface for MainLoopManager to tell characters what to do
/// Set king, guest, jester from their respective objects in the main scene
/// 
/// </summary>
public class Characters : MonoBehaviour
{
    [SerializeField] public Texture _jesterJuggle;
    [SerializeField] public Texture _jesterNeutral;
    [SerializeField] public Texture _jesterTada;

    [SerializeField] public Texture _bloodBeardNeutral;
    [SerializeField] public Texture _bloodBeardPositive;
    [SerializeField] public Texture _bloodBeardNegative;

    [SerializeField] public Texture _ladyNeutral;
    [SerializeField] public Texture _ladyPositive;
    [SerializeField] public Texture _ladyNegative;
 
    [SerializeField] public Texture _popeNeutral;
    [SerializeField] public Texture _popePositive;
    [SerializeField] public Texture _popeNegative;

    [HideInInspector] public CharacterList _characterList;
    public static Characters _instance;
    private void Awake()
    {
        _instance = this;
    }

    public void DoJesterNeutral() 
    {
        _characterList._jester.SetTrigger("Neutral");
        _characterList._jester.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _jesterNeutral);
    }
    public void DoJesterPhysicalJoke()
    {
        _characterList._jester.SetTrigger("Perform");
        _characterList._jester.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _jesterJuggle);

    }

    public void DoJesterVerbalJoke()
    {
        _characterList._jester.SetTrigger("Perform");
        _characterList._jester.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _jesterTada);

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

        if (_characterList._currentGuest.transform.name.ToLower().Contains("lady"))
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _ladyPositive);
        }
        else if (_characterList._currentGuest.transform.name.ToLower().Contains("pope"))
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _popePositive);
        }
        else
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _bloodBeardPositive);
        }
    }

    public void DoGuestNeutralReaction()
    {
        _characterList._currentGuest.SetTrigger("Neutral");


        if (_characterList._currentGuest.transform.name.ToLower().Contains("lady"))
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _ladyNeutral);
        }
        else if (_characterList._currentGuest.transform.name.ToLower().Contains("pope"))
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _popeNeutral);
        }
        else
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _bloodBeardNeutral);
        }

    }

    public void DoGuestNegativeReaction()
    {
        _characterList._currentGuest.SetTrigger("Neg");

        if (_characterList._currentGuest.transform.name.ToLower().Contains("lady"))
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _ladyNegative);
        }
        else if (_characterList._currentGuest.transform.name.ToLower().Contains("pope"))
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _popeNegative);
        }
        else
        {
            _characterList._currentGuest.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BaseMap", _bloodBeardNegative);
        }
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
