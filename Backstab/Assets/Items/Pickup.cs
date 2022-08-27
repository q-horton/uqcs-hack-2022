using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickup;
    private float MoveSpeed = 100f;
    Transform target;
    

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerStats ps = other.gameObject.GetComponent<PlayerStats>();
            if (!ps.isInventoryFull()) {
                ps.inventory[ps.getFirstOpenInvSlot()] = pickup;
                pickup.transform.position = target.position;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("InvenSlot").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
