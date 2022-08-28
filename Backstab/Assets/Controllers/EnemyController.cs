 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 99f;
    public float attackRadius = 6f;
    public float timeBetweenAttacks = 2f;
    
    public int attackDamage = 5;
    public float lastHit = 0f;

    public Transform target ;
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
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);
            //float sporaticAttack = Random.Range(0f, 0.5f);
            //if (distance <= attackRadius) {
             //   if (Time.time >= Time.time + sporaticAttack) {
               //     if (distance <= attackRadius) {
                        attackPlayer();
                        Debug.Log("attacking the player");
                    }
                 //   if (distance <= agent.stoppingDistance) {
                 //       FaceTarget();
                 //   }
              //  }   
         //   }
            
            
      //  }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void attackPlayer() {
        if (Time.time > lastHit + timeBetweenAttacks) {
            target.GetComponentInChildren<CharacterStats>().TakeDamage(attackDamage);
            lastHit = Time.time;
        }
    }
    
}