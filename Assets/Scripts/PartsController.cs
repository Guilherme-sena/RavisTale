using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PartsController : MonoBehaviour
{
        
    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag =="Bubble" && other.transform.childCount == 0){
            transform.SetParent(other.transform);
            transform.GetComponent<Collider2D>().isTrigger = true;
            transform.localPosition = Vector2.zero;
        }
    } 
    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.tag == "Bubble"){
            transform.GetComponent<Collider2D>().isTrigger = false; 
            transform.localScale = Vector3.one;     
        }
   }

}
