using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed = 0.3f;
    float offset;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMovement.instance.TryingToMoveButStuck()){
            if(Input.GetKey(KeyBinds.instance.leftMoving)){
                offset -= (Time.deltaTime * scrollSpeed) / 10f;
                mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
            else if(Input.GetKey(KeyBinds.instance.rightMoving)){
                offset += (Time.deltaTime * scrollSpeed) / 10f;
                mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }
    }
}
