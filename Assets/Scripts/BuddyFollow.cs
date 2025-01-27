using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BuddyFollow : MonoBehaviour
{

   public Transform target;
   public float smoothing = 0.1f;

   public Vector3 offSet = new Vector3(0.5f,0.5f,0f);

   public float Distance(Vector2 a, Vector2 b)
   {
        return Vector2.Distance(transform.position, target.transform.position);

   }
   void LateUpdate(){
        if(transform.position != target.position){
            Vector3 targetPosition =new Vector3(target.position.x,target.position.y,0);
            transform.position = Vector3.Lerp(transform.position,targetPosition - offSet,smoothing);
        }

   }
}


