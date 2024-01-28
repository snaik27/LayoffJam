using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    [SerializeField] public Animator _king;
    [SerializeField] public Animator _jester;
    [SerializeField] public List<Animator> _guestAnimators;
    public Animator _currentGuestAnimator => _guestAnimators[(int)_currentCharacter];

    public Character _currentCharacter => _characters[_currentGuestIndex % _characters.Length];

    private int _currentGuestIndex;
    private Character[] _characters = { Character.Lady, Character.BloodBeard, Character.Pope };
    public enum Character
    {
        Lady = 0,
        BloodBeard = 1,
        Pope = 2
    }

    private void Awake()
    {
        foreach(Animator guestAnim in _guestAnimators)
        {
            guestAnim.gameObject.SetActive(false);
        }

        ShuffleCharacterList();
        _currentGuestIndex = 0;
        NextCharacter();
        Characters._instance._characterList = this;
    }

    public void NextCharacter()
    {
        _currentGuestAnimator.gameObject.SetActive(false);
        _currentGuestIndex++;
        _currentGuestAnimator.gameObject.SetActive(true);

        GameStateManager._instance._guest.name = _currentCharacter.ToString();
    }

    private void ShuffleCharacterList()
    {
        for (int i = 0; i <  _characters.Length; i++)
        {
            int randomIdx = Random.Range(0, _characters.Length);
            (_characters[i], _characters[randomIdx]) = (_characters[randomIdx], _characters[i]);
        }
    }
}
