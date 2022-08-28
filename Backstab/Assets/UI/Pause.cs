using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject PlayerHUD;
    
    // Start is called before the first frame update
    void Start()
    {
        Globals.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (Globals.isPaused) {
                Resume();
            } else {
                PauseGame();
            }
        }
    }

    public void Resume() {
        PauseMenu.SetActive(false);
        PlayerHUD.SetActive(true);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Globals.isPaused = false;
    }

    void PauseGame() {
        PauseMenu.SetActive(true);
        PlayerHUD.SetActive(false);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Globals.isPaused = true;
    }
}
