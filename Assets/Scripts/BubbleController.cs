using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEditor.Search;
using UnityEngine;

public class BubbleController : MonoBehaviour
{

    private Transform lastbubble;
    public GameObject bubble_pop;
    public AudioClip bubblePopEffect;
    public Transform gun_position;
     public AudioSource audioSource;
    public  GameObject _prefab_bubble;
    [SerializeField] private float _bubbleSpeed;
    

    void Start(){
        audioSource = GetComponent<AudioSource>();


    }
    void Update(){
       foreach (Transform child in transform){
            if(child.gameObject.GetComponent<SpriteRenderer>().enabled == false){
                child.localScale = new Vector3(1,1,1); 
                child.DetachChildren();

            }
            if(child.position.y > 30 && child.transform != null ){
                Destroy(child.gameObject);
            }
       }
{
    //child is your child transform
}
    }
    public void ApplyMovement(Transform obj)
    {
        if(obj.transform != null){

            StartCoroutine(MoveToCoroutine(obj, new Vector2(obj.position.x,obj.position.y +30.0f), 15));
        }
        //obj.Translate(0f ,_bubbleSpeed*Time.deltaTime,0f);
    }
    public Transform GetLastBubble()
    {
        return transform.GetChild(transform.childCount -1);
    }
    public void ControllSize(Transform obj)
    {
        obj.localScale += new Vector3( Time.deltaTime, Time.deltaTime,1);
        if(obj.localScale.x > 5){
            obj.localScale = new Vector3(5,5,0);
        }
    }
    public void Spawn(){
        Instantiate(_prefab_bubble,gun_position.position ,_prefab_bubble.transform.rotation,parent:transform);
        
    }


    public IEnumerator MoveToCoroutine(Transform targ, Vector3 pos, float dur)
{

    float t = 0f;

         Vector3 start = targ.position;
         Vector3 v = pos - start;
        while(t < dur)
        {
            
            if(targ.position != null){

            t += Time.deltaTime * _bubbleSpeed;
            targ.position = start + v * t / dur;
            yield return null;
            }
        
        }
        if(targ != null)
        {
            targ.position = pos;
        }
   
    
}
public void POP(Transform bubble){
    bubble.GetComponent<SpriteRenderer>().enabled = false;
    audioSource.clip = bubblePopEffect;
    audioSource.Play();
    Instantiate(bubble_pop,bubble.transform.position,bubble.transform.rotation);
}
}
    
