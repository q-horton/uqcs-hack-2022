using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    public float lookRadius = 50f;
    public float attackRadius = 3f;
    float timeBetweenAttacks = 5f;
    public bool evil = false;
    
    public int attackDamage = 2;
    float lastHit;

    public Transform target;
    public Transform ally;
    public NavMeshAgent agent;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    // Start is called before the first frame update
    void Start()
    {
        ally = PlayerManager.instance.player.transform;
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (!evil) {
            if (target == null) {
                target = GameObject.FindGameObjectWithTag("Enemy").transform;
                if (target == null) {
                    agent.SetDestination(ally.position);
                }
            }
            }
            int health = GetComponentInChildren<CharacterStats>().health;
            int maxHealth = GetComponentInChildren<CharacterStats>().getMaxHealth();
            if (health > 0.5 * maxHealth) {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius) {
                agent.SetDestination(target.position);
                if (distance <= attackRadius) {
                    attackEntity();
                }
            }
            }
            if (health <= 0.5 * maxHealth) {
                float distance = Vector3.Distance(ally.position,transform.position);
                agent.SetDestination(target.position);
            }   

        if (evil) {
                agent.SetDestination(target.position);
                attackEntity();
            }
    }

    void attackEntity() {
        if (Time.time > lastHit + timeBetweenAttacks) {
            if (!evil) {
            target.GetComponent<EnemyStats>().TakeDamage(attackDamage);
            } else {
                target.GetComponent<CharacterStats>().TakeDamage(attackDamage);
            }
            lastHit = Time.time;
        }
    }
}

