using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public LayerMask Layer;
    public float lookRadius = 5000f;
    public float attackRadius = 3f;
    float timeBetweenAttacks = 5f;
    public bool evil = false;
    
    public int attackDamage = 2;
    float lastHit;

    public Transform target;
    public Transform ally;
    public NavMeshAgent agent;
    public GameObject[] targets;
    public int health = 10;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    void Awake()
    {
        Layer = LayerMask.GetMask("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        ally = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject t in targets) {
            target = t.transform;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (!evil) {
            if (target == null) {
                targets = GameObject.FindGameObjectsWithTag("Enemy");   
                foreach (GameObject t in targets) {
                    target = t.transform;
                    break;
                }
            }
            
            if (target != null) {
                health = GetComponentInChildren<CharacterStats>().health;
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
            }
        }
        if (evil) {
                Layer = LayerMask.GetMask("Enemy");
                agent.SetDestination(ally.position);
                attackEntity();
            }
    }

    void attackEntity() {
        if (Time.time > lastHit + timeBetweenAttacks) {
            if (!evil) {
                target.GetComponent<EnemyStats>().TakeDamage(attackDamage);
            } else {
                ally.GetComponent<CharacterStats>().TakeDamage(attackDamage);
            }
            lastHit = Time.time;
        }
    }
}

