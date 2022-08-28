using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void StartMenu() {
        ChangeScene("Start Menu");
    }

    public void SwarmArena() {
        ChangeScene("SwarmArena");
    }

    public void BossBattle() {
        ChangeScene("BossBattle");
    }

    public void QuitGame() {
        Application.Quit();
    }

}
