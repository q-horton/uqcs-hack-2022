using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public Text Timer;
    public float timeRemaining;
    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 300;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        minutes = Mathf.FloorToInt(timeRemaining/60);
        seconds = Mathf.FloorToInt(timeRemaining) - minutes * 60;

        Timer.text = minutes.ToString() + ":" + seconds.ToString();

        if (timeRemaining <= 0) {
            print("level out");
            Timer.text = "";
            SceneManager.LoadScene("BossLevel");
        }
    }
}
