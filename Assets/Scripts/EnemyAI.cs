using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget;
    bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }

        
        else if(distanceToTarget <= chaseRange)
        {
             
             isProvoked = true;
        }
        
        
       
    }
     void OnDrawGizmosSelected()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
    void EngageTarget()
    {
        // stopping distance player'in yanina gelme uzakligi. 
        // stopping distance'i 1 yaparsam 1 birim yanina gelene kadar takip edecek.
        if (distanceToTarget >= navMeshAgent.stoppingDistance) 
        {
            ChaseTarget();
        }

        //stopping distance seviyesine gelirse o zaman saldirmaya baslayacak.
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

   
    void AttackTarget()
    {
        Debug.Log(name + "has seeked and is destroying" + target.name);
    }
}
