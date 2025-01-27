using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour
{
    public BubbleController BB;
    void Start()
    {
        BB = FindObjectOfType<BubbleController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BB.partCount >=2){
            transform.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
