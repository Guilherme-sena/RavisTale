using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BubbleController : MonoBehaviour
{
    public LevelLoader levelLoader;
    public string sceneName;
    public TextMeshProUGUI textPartCount;

    public AudioClip successSFX;
    public int partCount = 0;
    private Transform lastbubble;
    private trocarDeCena trocarDeCena;
    public GameObject bubble_pop;
    public AudioClip bubblePopEffect;
    public Transform gun_position;
    public AudioSource audioSource;
    public  GameObject _prefab_bubble;
    [SerializeField] private float _bubbleSpeed;

    private float yDistance;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        trocarDeCena = FindObjectOfType<trocarDeCena>();

    }
    void Update(){
        textPartCount.text = partCount + "/3 Peças";
        
       if (partCount == 3){
            levelLoader.Transition(sceneName);
        //SceneManager.LoadScene(2);
       }
       foreach (Transform child in transform){
            yDistance = Mathf.Abs(child.position.y - gun_position.position.y);
            if (child.gameObject.GetComponent<SpriteRenderer>().enabled == false){
                child.localScale = new Vector3(1,1,1);
                child.gameObject.GetComponentInChildren<Transform>().localScale = Vector3.one;
                child.DetachChildren();

            }
            if(yDistance > 16 && child.transform != null ){
                 foreach (Transform child2 in child){
                    if(child2.tag == "SubPart"){
                        audioSource.clip = successSFX;
                        audioSource.Play();
                        partCount ++;

                    }
                 }

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
    bubble.GetComponent<Collider2D>().enabled = false;
    bubble.GetComponent<SpriteRenderer>().enabled = false;
    audioSource.clip = bubblePopEffect;
    audioSource.Play();
     GameObject Effect= Instantiate(bubble_pop,bubble.transform.position,bubble.transform.rotation);
     Effect.transform.localScale = (bubble.localScale);
}
}