using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    int maxHealth = 20;
    public int health { get; private set; }
    public Stat armor;
    public HealthBar healthBar;

    public int getMaxHealth() {
        return maxHealth;
    }

    public int getHealth() {
        return health;
    }

    public void healthBoost(float scale) {
        maxHealth = Mathf.FloorToInt(maxHealth * scale);
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
        damage = Mathf.RoundToInt(damage * (100 - armor.getValue())/100);
        damage = Mathf.Clamp(damage, 0, int.MaxValue); 
        //Stops damage from making health go negative
        health -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        healthBar.SetHealth(health);
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Awake() {
        health = getMaxHealth();
    }

    // Update is called once per frame
    void Update() 
    {
        if (health <= 0) {
            Die();
        }
    }

    public virtual void Die()
    {
        Globals.isDead = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
