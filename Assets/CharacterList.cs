using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    [SerializeField] public Animator _king;
    [SerializeField] public Animator _jester;
    [SerializeField] public List<Animator> _guests;
    public Animator _currentGuest;
    public Character _currentGuestName;
    public enum Character
    {
        Lady = 0,
        BloodBeard = 1,
        Pope = 2
    }

    private void Awake()
    {
        ChooseRandomCharacter();
        Characters._instance._characterList = this;
    }

    public void ChooseRandomCharacter()
    {
        int randomCharacter = Random.Range(0, _guests.Count - 1);


        _currentGuest = _guests[randomCharacter];
        if(randomCharacter == 0)
        {
            _currentGuestName = Character.Lady;
        }
        else if(randomCharacter == 1)
        {
            _currentGuestName = Character.BloodBeard;
        }
        else
        {
            _currentGuestName = Character.Pope;
        }


        foreach(Animator guest in _guests)
        {
            if(guest != _currentGuest)
            {
                guest.gameObject.SetActive(false);
            }
        }

        _guests.Remove(_currentGuest);

        GameStateManager._instance._guest.name = _currentGuestName.ToString();
    }
}
