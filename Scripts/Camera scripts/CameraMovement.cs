using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rbCamera;
    public static CameraMovement instance;

    //moving down/looking down variables
    public Transform downLimit;
    public float camerMoveDownSpeed = 2f;
    public LayerMask downLimitLayer;
    //
    
    private void Awake() {
        rbCamera = GetComponent<Rigidbody2D>();
        instance = this;
        Vector3 movingDownLimit = downLimit.position;
        movingDownLimit.z = transform.position.z;
        downLimit.position = movingDownLimit;
    }

    private void Update() {
        LookingDown();
    }

    void LookingDown(){
        if(PlayerMovement.instance.IsGrounded()){
            if(Input.GetKey(KeyBinds.instance.downCrouch)){
                rbCamera.velocity = new Vector2(rbCamera.velocity.x, -camerMoveDownSpeed);
                if(IsAtLookingDownLimit()){
                    rbCamera.velocity = new Vector2(0, 0);
                }
            }
            if(Input.GetKeyUp(KeyBinds.instance.downCrouch)){
                if(rbCamera.velocity == new Vector2(rbCamera.velocity.x, -camerMoveDownSpeed))
                    rbCamera.velocity = new Vector2(0, 0);
                CameraFollowPlayer.instance.ResettingToPlayerPosition();
            }
        }
    }

    bool IsAtLookingDownLimit(){
        return (transform.position.y - downLimit.position.y < 0);
    }

}
