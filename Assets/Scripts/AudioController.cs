using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip MainClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeMusic(AudioClip newMusic){
        if(audioSource.clip.name == newMusic.name){
            return;
        }
        audioSource.Stop();
        audioSource.clip = newMusic;
        audioSource.Play();
    }
    public void resetMusic(){
        audioSource.Stop();
        audioSource.clip = MainClip;
        audioSource.Play();
    }
}
