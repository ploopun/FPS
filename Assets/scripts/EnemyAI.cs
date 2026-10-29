using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;

    [SerializeField] float chaseRange = 5f;

    [SerializeField] bool isProvoked = false;

    float distanceToTarget = Mathf.Infinity;

    NavMeshAgent nma;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }

        else if(distanceToTarget <= chaseRange);
        {
           isProvoked = true;
        }

        
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= nma.stoppingDiatance)
        {
            ChaseTarget();
        }

        if(distanceToTarget <= nma.stoppingDiatance)
        {
            AttackTarget();
        }


    }

    private void ChaseTarget()
    {
        nma.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        print(name + "is attacking" + target.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }






}
