using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinds : MonoBehaviour
{
    public static KeyBinds instance;
    public KeyCode jump = KeyCode.W;
    public KeyCode downCrouch = KeyCode.S;
    public KeyCode reloadLvl = KeyCode.R;
    public KeyCode lastCheckpoint = KeyCode.F;
    public KeyCode leftMoving = KeyCode.A;
    public KeyCode rightMoving = KeyCode.D;


    private void Awake() {
        instance = this;
    }
}
