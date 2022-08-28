 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 99f;
    public float attackRadius = 6f;
    float timeBetweenAttacks = 5f;
    
    public int attackDamage = 5;
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
            float sporaticAttack = Random.Range(0f, 1.5f);
            if (distance <= attackRadius) {
                if (Time.time >= Time.time + sporaticAttack) {
                    if (distance <= attackRadius) {
                        attackPlayer();
                        Debug.Log("attacking the player");
                    }
                }   
            }
            
            
        }
    }
    void attackPlayer() {
        if (Time.time > lastHit + timeBetweenAttacks) {
            target.GetComponent<CharacterStats>().TakeDamage(attackDamage);
            lastHit = Time.time;
            Debug.Log("attack reset");
        }
    }
}