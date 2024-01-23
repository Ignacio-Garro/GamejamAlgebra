using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float timeBeforeReloadLvl = 2f;
    
    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyBinds.instance.reloadLvl))
        {
            PlayerPrefs.DeleteKey(SceneManager.GetActiveScene().name);
            ReloadLevel();
        }

        if(Input.GetKeyDown(KeyBinds.instance.lastCheckpoint))
            ReloadLevel();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerDeath()
    {
        Invoke(nameof(ReloadLevel), timeBeforeReloadLvl);
    }
}
