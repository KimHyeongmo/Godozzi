using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_effect : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void play_sound()
    {
        audioSource.Play();
    }
}
