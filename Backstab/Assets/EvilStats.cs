using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = GetComponent<CharacterStats>().getMaxHealth();
        currentHealth = GetComponent<CharacterStats>().health;
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        if (currentHealth <= damage) {
            Die();
        }
    }

    void Die() {
        //Game Over Message
        Destroy(gameObject);
    }
}
