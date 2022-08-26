using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    int maxHealth = 20;
    public int health { get; private set; }
    public Stat damage;
    public Stat armor;
    public HealthBar healthBar;

    public int getMaxHealth() {
        return maxHealth;
    }

    public int getHealth() {
        return health;
    }

    public void TakeDamage(int damage) {
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); 
        //Stops damage from making health go negative
        health -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        healthBar.SetHealth(health);
        if (health <= 0) {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Awake() {
        health = getMaxHealth();
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public virtual void Die()
    {
        // add die UI
        Debug.Log(transform.name + " died.");
    }
}
