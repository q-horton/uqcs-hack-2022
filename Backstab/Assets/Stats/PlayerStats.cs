using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject[] inventory;

    int inventorySize = 5;

    public bool isInventoryFull() {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == null) {
                return false;
            }
        }
        return true;
    }

    public int getFirstOpenInvSlot() {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == null) {
                return i;
            }
        }
        return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = new GameObject[inventorySize];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
