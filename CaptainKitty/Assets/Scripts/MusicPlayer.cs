using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void Update()
    {
        if (Input.GetKeyDown("+") || Input.GetKeyDown("="))
        {
            Debug.Log("Increase volume");
            if (_audioSource == null)
            {
                _audioSource = FindObjectOfType<AudioSource>();
                //GetComponent<AudioSource>();

            }
            if ((_audioSource != null) && (_audioSource.volume < 0.9f))
            {
                _audioSource.volume += .1f;
                Debug.Log("Volume is now " + _audioSource.volume);
            }
        }
        if (Input.GetKeyDown("-"))
        {
            Debug.Log("Decrease volume");
            if (_audioSource == null)
            {
                _audioSource = FindObjectOfType<AudioSource>();
                //GetComponent<AudioSource>();

            }
            if ((_audioSource != null) && (_audioSource.volume > 0.1f))
            {
                _audioSource.volume -= .1f;
                Debug.Log("Volume is now " + _audioSource.volume);
            }
        }
    }
}