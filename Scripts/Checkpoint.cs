using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public string nameOfCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            if(PlayerPrefs.GetString(SceneManager.GetActiveScene().name) == nameOfCheckpoint)
            {
                PlayerMovement.instance.transform.position = transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Uslo");
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name, nameOfCheckpoint);
        }
    }
}
