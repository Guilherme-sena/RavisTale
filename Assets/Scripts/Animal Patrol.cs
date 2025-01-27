using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class AnimalPatrol : MonoBehaviour
{
    public GameObject patrolPointsGO;
    public BubbleController BB;
    public GameObject bubblePop;
    private List<Transform> points = new List<Transform>();
    public float _speed = 3.0f;
    public int targetPoint;
    void Start()
    {
        targetPoint = 0;
          BB = FindObjectOfType<BubbleController>();
         foreach (Transform child in patrolPointsGO.transform)
        {
         points.Add(child);   
        }
    }


    void Update()
    {
        if(transform.position == points[targetPoint].position){
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position,points[targetPoint].position,_speed * Time.deltaTime);
    }
    private void increaseTargetInt(){
        targetPoint++;
        if(targetPoint ==  patrolPointsGO.transform.childCount){
            targetPoint = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag =="Bubble"){
            BB.POP(other.transform);
        }
    }

}
