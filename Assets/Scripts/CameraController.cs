using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform target;
   public float smoothing = 0.1f;
   public Vector2 minPosition;
   public Vector2 maxPosition;
   public bool changeCamera = false;

   public void CameraUpdate(Vector2 min,Vector2 max){
       if(transform.position != target.position){
            Vector3 targetPosition =new Vector3(target.position.x,target.position.y,transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,min.x,max.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,min.y,max.y);
            transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing);
        }

   }
   void LateUpdate(){
    if(changeCamera == false){
        if(transform.position != target.position){
            Vector3 targetPosition =new Vector3(target.position.x,target.position.y,transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,minPosition.x,maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,minPosition.y,maxPosition.y);
            transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing);
        }

    }
   }
}
