using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInventory : MonoBehaviour
{
    public PlayerStats stats;
    public Text jump;
    public Text regen;
    public Text strength;
    public Text speed;
    public Text armour;
    public Text reach;
    
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
        jump.text = Globals.inventory[0].ToString();
        regen.text = Globals.inventory[1].ToString();
        strength.text = Globals.inventory[2].ToString();
        speed.text = Globals.inventory[3].ToString();
        armour.text = Globals.inventory[4].ToString();
        reach.text = Globals.inventory[5].ToString();
    }
}
