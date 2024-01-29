using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [SerializeField] AudioSource _audioSource;

    [SerializeField] AudioClip _cheer;
    [SerializeField] AudioClip _crickets;
    [SerializeField] AudioClip _boo;
    [SerializeField] List<AudioClip> _buttonClicks;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomButtonClick()
    {
        _audioSource.PlayOneShot(_buttonClicks[Random.Range(0, _buttonClicks.Count)]);
    }

    public void PlayCrickets()
    {
        _audioSource.PlayOneShot(_crickets);
    }

    public void PlayCheer()
    {
        _audioSource.PlayOneShot(_cheer);
    }

    public void PlayBooh()
    {
        _audioSource.PlayOneShot(_boo);
    }

}
