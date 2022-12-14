using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats ps;
    static float baseAttackRange = 4f;
    static int baseAttackDamage = 50;

    public Transform attackPoint;
    public float attackRange = baseAttackRange;
    public LayerMask Enemy;
    public int attackDamage = baseAttackDamage;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            Attack();
        }
        attackRange = baseAttackRange * ps.reach;
        attackDamage = Mathf.FloorToInt(baseAttackDamage * ps.strength);
    }

    void Attack() {
        //Play attack animation
        // detect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, Enemy);
        if (hitEnemies != null) {
            foreach(Collider e in hitEnemies)
            {   
                if (e == null) {
                    Debug.Log("no e");
                }
                Debug.Log("we hit" + e.name);
                e.GetComponentInParent<EnemyStats>().TakeDamage(attackDamage);
                
            }
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
