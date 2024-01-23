using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public static CameraFollowPlayer instance; 
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowingPlayer();
    }

    private void FollowingPlayer(){
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Player.position.x;
        transform.position = cameraPosition;
    }

    [HideInInspector] public void ResettingToPlayerPosition(){
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = Player.position.y;
        transform.position = cameraPosition;
    }
}
