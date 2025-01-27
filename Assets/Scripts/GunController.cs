using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GunController : MonoBehaviour
{
    public GameObject _player;
    private Vector2 _playerPosition;
    private Vector2 constOffset = new Vector2(0.5f,0f);
    private void Update(){
         _playerPosition = _player.GetComponent<PlayerController>()._input;
           //If player is moving down, move gun fire point downards
        if(_playerPosition.y < -0.01){
            gameObject.transform.localPosition =new  Vector3(0f,-0.5f,0f);
        }
         //If player is moving up, move gun fire point upwards
        if(_playerPosition.y > 0.01){
              gameObject.transform.localPosition =new  Vector3(0f,0.5f,0f);
        }
        //If player is moving right or left reset position
        if(_playerPosition.x > 0.01 || _playerPosition.x < -0.01f){
              gameObject.transform.localPosition =constOffset;
        }
    }


}


