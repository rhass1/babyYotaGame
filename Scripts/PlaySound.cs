using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource audio;
    public AudioClip explodeSFX;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Explode()
    {
        audio.PlayOneShot(explodeSFX);
    }
}
