using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal.Internal;

public class StartMenu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public string sceneName;
    public VideoPlayer videoPlayer;
    
    private bool isLooping = true;
    private double loopTime = 1.9;
    void Start()
    {
        videoPlayer.loopPointReached += CheckVideoEnd;
    }

    void Update()
    {
        if (isLooping && videoPlayer.time >= loopTime)
        {
            videoPlayer.Stop();
            videoPlayer.time = 0;
            videoPlayer.Play();
        }
    }
    public void StopLoop()
    {
        isLooping = false;
    }

    private void CheckVideoEnd(VideoPlayer vp)
    {
        if (!isLooping)
        {
            levelLoader.Transition(sceneName);
        }
    }
}
