using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 6f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget;
    bool isProvoked = false;
    Animator attackAnim;
    Animator moveAnim;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        moveAnim = gameObject.GetComponent<Animator>();
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
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
        
    }
    void EngageTarget()
    {
        FaceTarget();
        // stopping distance player'in yanina gelme uzakligi. 
        // stopping distance'i 1 yaparsam 1 birim yanina gelene kadar takip edecek.

        if (distanceToTarget >= navMeshAgent.stoppingDistance) 
        {
            ChaseTarget();
            GetComponent<Animator>().SetBool("Attack", false);
        }

        //stopping distance seviyesine gelirse o zaman saldirmaya baslayacak.
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
            
        }
    }


   
    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
        Debug.Log(name + "has seeked and is destroying" + target.name);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

    }
}
