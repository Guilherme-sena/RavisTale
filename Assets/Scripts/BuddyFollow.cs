using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BuddyFollow : MonoBehaviour
{

   public Transform player;
public float speed = 1f;

   public float Distance(Vector2 a, Vector2 b)
   {
        return Vector2.Distance(a, b);

   }
   void LateUpdate(){
      if(Distance(transform.position,player.position) <8){

          //if moving right
        if(transform.position.x - player.position.x > 0 && Distance(transform.position,player.position) > 1 ){
          transform.localScale = new Vector3(1,1,1);
          transform.position  =Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
        }
        if(transform.position.x - player.position.x < 0 &&  Distance(transform.position,player.position) > 1){
          transform.localScale = new Vector3(-1,1,1);
          transform.position  =Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
        }
      }

   }
}


