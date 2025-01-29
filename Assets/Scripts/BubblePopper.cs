using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public BubbleController BB;
    // Start is called before the first frame update
    void Start()
    {
        BB = FindObjectOfType<BubbleController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Bubble"){
            BB.POP(other.transform);
        }
        
    }
}

