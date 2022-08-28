using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{

    public GameObject SettingsMenu;
    public GameObject MainMenu;

    bool inSettings;
    
    // Start is called before the first frame update
    void Start()
    {
        inSettings = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inSettings) {
            Close();
        }
    }

    public void Open() {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        inSettings = true;
    }

    void Close() {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        inSettings = false;
    }
}
