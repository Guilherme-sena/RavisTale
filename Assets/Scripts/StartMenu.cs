using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Arraste o VideoPlayer pelo Inspector
    private bool isLooping = true;
    private double loopTime = 1.9; // Tempo limite para o loop (2 segundos)

    void Start()
    {
        videoPlayer.loopPointReached += CheckVideoEnd;
    }

    void Update()
    {
        // Verifica se deve manter o v�deo em loop at� 2 segundos
        if (isLooping && videoPlayer.time >= loopTime)
        {
            videoPlayer.Stop();
            videoPlayer.time = 0;
            videoPlayer.Play();
        }
    }

    // Chamado pelo bot�o na UI
    public void StopLoop()
    {
        isLooping = false; // Desabilita o loop, permite reprodu��o normal
    }

    private void CheckVideoEnd(VideoPlayer vp)
    {
        if (!isLooping)
        {
            SceneManager.LoadScene(1); // Troca para a cena 1 ao fim do v�deo
        }
    }
}
