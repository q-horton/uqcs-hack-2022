using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 4f;
    public LayerMask enemy;
    public int attackDamage = 50;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            Attack();
        }
    }

    void Attack() {
        //Play attack animation
        // detect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemy);
        foreach(Collider enemy in hitEnemies)
        {
            //Attack enemies
            enemy.GetComponent<EnemyStats>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null) {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
