using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInventory : MonoBehaviour
{
    public PlayerStats stats;
    GameObject inventory = GameObject.Find("Overlay/Inventory");
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < stats.inventory.Length; i++) {
            Text txt = GameObject.Find("Overlay/Inventory/Slot " + (i+1) + "/Score " + (i+1)).GetComponent<Text>();
            txt.text = stats.inventory[i].ToString();
        }
    }
}
