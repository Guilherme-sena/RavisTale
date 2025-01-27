using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStages : MonoBehaviour
{
    public Vector2 NewMinPos;
    public Vector2 NewMaxPos;
    public Vector3 playerChange;
    private CameraController CC;

    void Start(){

        CC = Camera.main.GetComponent<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.position += playerChange;
            CC.maxPosition = NewMaxPos;
            CC.minPosition = NewMinPos;
        }
    }
}
