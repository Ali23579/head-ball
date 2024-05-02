using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour
{
    public AudioClip musicclip;
    private AudioSource musicsource;

    void Start()
    {
        musicsource = gameObject.AddComponent<AudioSource>();
        musicsource.clip = musicclip;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            musicsource.Play();
        }
    }
}
