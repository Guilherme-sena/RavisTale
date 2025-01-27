using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using System.Linq;
using System.IO;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public Interectable Interectable {get; set;}

    public Animator animator;
    private String FireButton = "Fire1";
    private bool _moving;
    private bool _canMove = true;
    [SerializeField] private float speed = 5f;
    private bool is_turned_right = true;
    Rigidbody2D _rb;
    private List<Transform> last_bubble_instance = new List<Transform>();

    public  Vector2 _input;
    private float x;
    private float y;
    private BubbleController BC;
    void Start()
    {
        BC = FindObjectOfType<BubbleController>();
        _rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if(dialogueUI.IsOpen){
            _canMove = false;
            _input = Vector2.zero;
        }
        if(_canMove == true){
            GetInput();
        
        if(Input.GetKey(KeyCode.E))
        {
            if(Interectable != null)
            {
                Interectable.Interact(this);
            }
        }
        
        }
        Animate();
        if(Input.GetButton(FireButton)){
            _canMove = false;
            _input = Vector2.zero;
            //Instancia a bolha 1 vez
            if(Input.GetButtonDown(FireButton))
            { 
                BC.Spawn();
                if(BC.transform.childCount > 0){
                    last_bubble_instance.Add(BC.GetLastBubble());  

                }
            }       
             if(last_bubble_instance != null){
            BC.ControllSize(last_bubble_instance.Last());
            }
        }   
        else{
            if(last_bubble_instance.Count >0 ){
                if(last_bubble_instance.Last() != null){
                    BC.ApplyMovement(last_bubble_instance.Last());
                }

            }
            _canMove = true; 
        }
    }

     private void FixedUpdate() {
        if(_canMove){
            _rb.velocity = _input * speed;

        }
        else{
            _rb.velocity = Vector2.zero;
        }

    }
    private void GetInput(){
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        _input = new Vector2(x,y);
        _input.Normalize();
        
    }
    
    private void Animate(){
        if(_input.x < -0.1f && is_turned_right == true){
            gameObject.transform.Rotate(0,180,0);
            is_turned_right = false;
        }

        if(_input.x > 0.1f && is_turned_right == false){
            gameObject.transform.Rotate(0,180,0);
            is_turned_right = true;
        }

        if(_input.magnitude > 0.1f || _input.magnitude < -0.1f){
            _moving = true;
        }
        else{
            _moving = false;
        }

        if (_moving){
            animator.SetFloat("X",x);
            animator.SetFloat("Y",y);
        }
        animator.SetBool("moving",_moving);
    }
 
}
