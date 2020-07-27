using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;


    public Transform[] patrolPts;
    public float patrolSpeed;
    int currentPatrolPt;

    Transform player;
    public float radiusOfAwareness;
    public float moveTowardsPlayerSpeed=5f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < radiusOfAwareness)
        {
            Vector3.MoveTowards(transform.position,player.position,moveTowardsPlayerSpeed*Time.deltaTime);
        }
        else
        {
            Patrol();
        }
        if (navMeshAgent.transform.position.x == navMeshAgent.destination.x &&navMeshAgent.transform.position.z == navMeshAgent.destination.z)
        {
            currentPatrolPt++;
            currentPatrolPt %= patrolPts.Length;
        }
    }

    void Patrol()
    {
        if (patrolPts.Length > 0)
        {
            navMeshAgent.destination = patrolPts[currentPatrolPt].position;          
        }
    }
}
