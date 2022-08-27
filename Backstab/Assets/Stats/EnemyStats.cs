using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    float dropRate = 1f;
    public GameObject pickup;

    public Material jump;
    public Material regen;
    public Material strength;
    public Material speed;
    public Material armour;
    public Material reach;     

    void Start() {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage) {
        currentHealth -= damage;
        
        //play hurt animation
        if (currentHealth <= 0) {
            Die();
        }


    }
    void Die() {
        //death animation
        
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        dropItem();
        prefabSpawner.EnemyCount --;
        Destroy(gameObject);

        

    }

    void dropItem() {
        if (Random.Range(0f, 1f) <= dropRate) {
            GameObject pu = Instantiate(pickup, transform.position, transform.rotation);
            int id = Random.Range(0,6);
            pu.GetComponent<ID>().Id = id;
            switch (id) {
                case 0:
                    pu.GetComponentInChildren<Renderer>().material = jump;
                    break;
                case 1:
                    pu.GetComponentInChildren<Renderer>().material = regen;
                    break;
                case 2:
                    pu.GetComponentInChildren<Renderer>().material = strength;
                    break;
                case 3:
                    pu.GetComponentInChildren<Renderer>().material = speed;
                    break;
                case 4:
                    pu.GetComponentInChildren<Renderer>().material = armour;
                    break;
                case 5:
                    pu.GetComponentInChildren<Renderer>().material = reach;
                    break;
            }
        }
    }

}

