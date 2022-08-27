using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float attackRadius = 7f;
    float timeBetweenAttacks = 5f;
    public int attackDamage = 2;
    float lastHit;

    Transform target;
    NavMeshAgent agent;

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
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius) {
            agent.SetDestination(target.position);
            if (distance <= attackRadius) {
                attackPlayer();
            }
            
        }
    }

    void attackPlayer() {
        if (Time.time > lastHit + timeBetweenAttacks) {
            target.GetComponent<CharacterStats>().TakeDamage(attackDamage);
            lastHit = Time.time;
        }
    }
}

