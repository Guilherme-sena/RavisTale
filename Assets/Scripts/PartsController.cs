using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PartsController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag =="Bubble" && other.transform.childCount == 0){
            transform.SetParent(other.transform);
            transform.localPosition = Vector2.zero;
        }
    }
}
