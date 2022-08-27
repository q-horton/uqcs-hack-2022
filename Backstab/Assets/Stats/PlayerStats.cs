using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int[] inventory = new int[6];

    public CharacterStats cs;

    public float jump = 1f;
    public float regen = 1f;
    public float strength = 1f;
    public float speed = 1f;
    public float armour = 1f;
    public float reach = 1f;

    int regenOld = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new int[6];
    }

    // Update is called once per frame
    void Update()
    {
        jump = 1f + 0.05f * inventory[0];
        regen = 1f + 0.01f * inventory[1];
        strength = 1f + 0.1f * inventory[2];
        speed = 1f + 0.05f * inventory[3];
        armour = 1f + 0.2f * inventory[4];
        reach = 1f + 0.02f * inventory[5];

        cs.armor.addBuff(armour);

        if (inventory[1] > regenOld) {
            cs.healthBoost(regen);
            regenOld = inventory[1];
        }
    }
}
