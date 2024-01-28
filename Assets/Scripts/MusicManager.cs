using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager _instance;
    public AudioSource _audioSource;

    [SerializeField] private AudioClip _openingTrack;
    [SerializeField] private AudioClip _mainLoopTrack;
    [SerializeField] private AudioClip _closingTrack;
    
    private void Awake()
    {
        _instance = this;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
    }
    public void PlayOpeningTrack()
    {
        _audioSource.clip = _openingTrack;
        _audioSource.Play();
    }

    public void PlayMainTrack()
    {
        _audioSource.clip = _mainLoopTrack;
        _audioSource.Play();
    }

    public void PlayEndingTrack()
    {
        _audioSource.clip = _closingTrack;
        _audioSource.Play();
    }
}
