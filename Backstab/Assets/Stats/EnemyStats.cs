using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

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
        Destroy(gameObject);

    }

}

