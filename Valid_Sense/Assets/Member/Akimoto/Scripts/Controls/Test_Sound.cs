using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Sound : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSource.PlayOneShot(sound);
    }
}
