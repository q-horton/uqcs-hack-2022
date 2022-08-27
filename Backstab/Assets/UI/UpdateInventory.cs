using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInventory : MonoBehaviour
{
    public PlayerStats stats;
<<<<<<< Updated upstream
    public Text jump;
    public Text regen;
    public Text strength;
    public Text speed;
    public Text armour;
    public Text reach;
=======
    public GameObject inventory;
>>>>>>> Stashed changes
    
    void Start() {
        jump = GameObject.Find("Score 1").GetComponent<Text>();
        regen = GameObject.Find("Score 2").GetComponent<Text>();
        strength = GameObject.Find("Score 3").GetComponent<Text>();
        speed = GameObject.Find("Score 4").GetComponent<Text>();
        armour = GameObject.Find("Score 5").GetComponent<Text>();
        reach = GameObject.Find("Score 6").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        jump.text = stats.inventory[0].ToString();
        regen.text = stats.inventory[1].ToString();
        strength.text = stats.inventory[2].ToString();
        speed.text = stats.inventory[3].ToString();
        armour.text = stats.inventory[4].ToString();
        reach.text = stats.inventory[5].ToString();
=======
        for (int i = 0; i < stats.inventory.Length; i++) {
            Text txt = inventory.GetComponent<Text>();
            txt.text = stats.inventory[0].ToString();
        }
>>>>>>> Stashed changes
    }
}
