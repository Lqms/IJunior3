using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip _coinSound;
    private AudioSource _audioSource;

    private void Start()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinSound()
    {
        _audioSource.PlayOneShot(_coinSound);
    }
}
