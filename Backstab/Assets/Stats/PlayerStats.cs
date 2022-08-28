using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public CharacterStats cs;

    public float jump = Globals.baseStats[0];
    public float regen = Globals.baseStats[1];
    public float strength = Globals.baseStats[2];
    public float speed = Globals.baseStats[3];
    public float armour = Globals.baseStats[4];
    public float reach = Globals.baseStats[5];

    int regenOld = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jump = Globals.baseStats[0] + 0.05f * Globals.inventory[0];
        regen = Globals.baseStats[1] + 0.01f * Globals.inventory[1];
        strength = Globals.baseStats[2] + 0.1f * Globals.inventory[2];
        speed = Globals.baseStats[3] + 0.05f * Globals.inventory[3];
        armour = Globals.baseStats[4] + 0.01f * Globals.inventory[4];
        reach = Globals.baseStats[5] + 0.02f * Globals.inventory[5];

        cs.armor.addBuff(armour);

        if (Globals.inventory[1] > regenOld) {
            cs.healthBoost(regen);
            regenOld = Globals.inventory[1];
        }
    }
}
