using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGlobals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.isDead = false;
        Globals.isPaused = false;

        Globals.baseStats[0] = 1f;
        Globals.baseStats[1] = 1f;
        Globals.baseStats[2] = 1f;
        Globals.baseStats[3] = 1f;
        Globals.baseStats[4] = 0f;
        Globals.baseStats[5] = 1f;

        Globals.inventory[0] = 0;
        Globals.inventory[1] = 0;
        Globals.inventory[2] = 0;
        Globals.inventory[3] = 0;
        Globals.inventory[4] = 0;
        Globals.inventory[5] = 0;
    }
}
