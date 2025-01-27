using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ChangeTimeline : MonoBehaviour
{
    public TimeLineController TC;
    public string Biome;
    void Start()
    {
        TC = FindObjectOfType<TimeLineController>(  );
    }


      private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            TC.Play(Biome);
            }
        }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            TC.Stop(Biome);
        }
    }

}