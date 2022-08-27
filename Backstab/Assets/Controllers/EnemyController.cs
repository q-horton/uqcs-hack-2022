using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 50f;
    public float attackRadius = 3f;
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
           if (distance != 0) {
            agent.SetDestination(target.position);
            float sporaticAttack = Random.Range(0f, 1.5f);
            if (distance <= attackRadius) {
                if (Time.time >= Time.time + sporaticAttack) {
                    if (distance <= attackRadius) {
                        attackPlayer();
                    }
                }   
            }
            
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

