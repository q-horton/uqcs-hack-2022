using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineAI;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    // Finds position of player and agent
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponents<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) {
            Patrolling();
        }
        if (playerInSightRange && !playerInAttackRange) {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange) {
            AttackPlayer();
        }

        }
    }

    private void Patrolling()
    {
         

    }

    private void ChasePlayer()
    {
        
    }

    private void AttackPlayer()
    {
        
    }
}
