using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 500f;
    public float attackRadius = 3f;
    float timeBetweenAttacks = 5f;
    
    public int attackDamage = 5;
    float lastHit;

    Transform target;
    Transform otherTarget;
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
        otherTarget = GameObject.FindGameObjectWithTag("NPC").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        float distance2 = Vector3.Distance(otherTarget.position, transform.position);
        if (distance != 0 && distance < distance2) {
            agent.SetDestination(target.position);
            float sporaticAttack = Random.Range(0f, 1.5f);
            if (distance <= attackRadius) {
                if (Time.time >= Time.time + sporaticAttack) {
                    if (distance <= attackRadius) {
                        attackPlayer(1);
                    }
                }   
            }
        
        } else if (distance != 0 && distance > distance2) {
            agent.SetDestination(otherTarget.position);
            float sporaticAttack = Random.Range(0f, 1.5f);
            if (distance <= attackRadius) {
                if (Time.time >= Time.time + sporaticAttack) {
                    if (distance <= attackRadius) {
                        attackPlayer(2);
                    }
                }   
            }
        }
    }

    void attackPlayer(int player) {
        if (Time.time > lastHit + timeBetweenAttacks) {
            if (player == 1) {
            target.GetComponent<CharacterStats>().TakeDamage(attackDamage);
            } else if (player == 2) {
                otherTarget.GetComponent<CharacterStats>().TakeDamage(attackDamage);
            }
            lastHit = Time.time;
        }
    }    
}

