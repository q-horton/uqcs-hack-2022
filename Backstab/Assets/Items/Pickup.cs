using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickup;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerStats ps = other.gameObject.GetComponent<PlayerStats>();
            ps.inventory[pickup.GetComponent<ID>().Id] += 1;
            Destroy(pickup);
        }
    }
}
