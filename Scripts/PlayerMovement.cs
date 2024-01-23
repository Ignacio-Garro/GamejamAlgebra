using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    //basic movement variables
    public float movementSpeed = 3f;
    public float jumpHeight = 5f;
    Rigidbody2D rb;
    public Transform groundContactPoint;
    public LayerMask ground;
    
    //

    //to check previous position with new
    Vector2 oldPosition;
    Vector2 newPosition;

    private void Awake() {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement(){   
        float inputX = Input.GetAxis("Horizontal");
        oldPosition = transform.position;
        rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);
        if(IsGrounded()){
            if(Input.GetKeyDown(KeyBinds.instance.jump)){
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            if(Input.GetKey(KeyBinds.instance.downCrouch)){
                
            }
        }
        newPosition = transform.position;
    }
    
    [HideInInspector] public bool IsGrounded(){
        return Physics2D.OverlapCircle(groundContactPoint.position, 0.2f, ground);
    }

    /// <summary>
    /// Checks if player is pressing movement keys but is still in the same spot
    /// </summary>
    /// <returns>returns true if he is not moving but is pressing buttons</returns>
    [HideInInspector] public bool TryingToMoveButStuck(){
        if(Input.GetKey(KeyBinds.instance.leftMoving) || Input.GetKey(KeyBinds.instance.rightMoving))
            return oldPosition == newPosition;
        else    
            return false;
    }
}
