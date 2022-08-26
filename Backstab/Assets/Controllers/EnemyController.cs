using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    float timeBetweenAttacks = 5f;

    Transform target;
    NavMeshAgent agent;
    bool alreadyAttacked;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
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
            attackPlayer();
            
        }
    }

    void attackPlayer() {
        if (!alreadyAttacked) {
            alreadyAttacked = true;

        }
        Invoke(nameof(ResetAttack), timeBetweenAttacks);

    }

    void ResetAttack() {
        alreadyAttacked = false; 
    }
}

