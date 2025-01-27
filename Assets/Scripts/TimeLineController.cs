using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    public PlayableDirector diretorCoral;
    public PlayableDirector diretorCave;
    public PlayableDirector diretorBeach;
    public void Play(string name){
        if(name == "Coral"){
            diretorCoral.Play();
            Stop("Cave");
            Stop("Beach");
        }

        if(name == "Beach"){
            diretorBeach.Play();
            Stop("Cave");
            Stop("Coral");
        }

        if(name == "Cave"){
            diretorCave.Play();
            Stop("Coral");
            Stop("Beach");
        }

    }
    public void Stop(string name){
        if(name == "Cave"){
            diretorCave.Stop();
        }
        if(name == "Coral"){
            diretorCoral.Stop();
        }
        if(name == "Beach"){
            diretorBeach.Stop();
        }


    }
    
    }
