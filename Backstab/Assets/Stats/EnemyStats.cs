using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    float dropRate = 1f;
    public GameObject pickup;         

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
            pu.GetComponent<ID>().Id = Random.Range(0,6);
        }
    }

}

