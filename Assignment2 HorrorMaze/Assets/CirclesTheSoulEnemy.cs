using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CirclesTheSoulEnemy : MonoBehaviour
{
    Transform player;
    PlayerMovement playerMovement;


    public float chaseRadius = 10f;
    bool isCHasingPlayer;
    NavMeshAgent navMeshAgent;

    List<GameObject> noOfSoulsInScene=new List<GameObject>();

    int rand;
    float collectableSoulStoppingDIstance = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = FindObjectOfType<PlayerMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        foreach (GameObject aSoulToCircleROund in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            noOfSoulsInScene.Add(aSoulToCircleROund);
        }


        rand = Random.Range(0, noOfSoulsInScene.Count);
        navMeshAgent.SetDestination(noOfSoulsInScene[rand].transform.position);
        navMeshAgent.stoppingDistance = collectableSoulStoppingDIstance;
    }

    // Update is called once per frame
    void Update()
    {


        if (navMeshAgent.destination == null)
        {
            int randomSOulToCircleRound = Random.Range(0, noOfSoulsInScene.Count);
        }

        if (Vector3.Distance(player.position, transform.position) < chaseRadius)
        {
            if (isCHasingPlayer == false)
            {
                //check if you're already chasing the player
                if (!playerMovement.isCrouching)
                {
                    //chaseThePlayer
                    isCHasingPlayer = true;
                    navMeshAgent.SetDestination(player.transform.position);
                }
                else if (playerMovement.isCrouching)
                {
                    //continueOnWith Movement
                }
            }
        }
        else if (Vector3.Distance(player.position, transform.position) > chaseRadius)
        {

            isCHasingPlayer = false;
        }

        for (var i = noOfSoulsInScene.Count - 1; i > -1; i--)
        {
            if (noOfSoulsInScene[i] == null)
                noOfSoulsInScene.RemoveAt(i);
        }


        if (Vector3.Distance(noOfSoulsInScene[rand].transform.position, transform.position) <= collectableSoulStoppingDIstance)
        {
            transform.RotateAround(noOfSoulsInScene[rand].transform.position, Vector3.up, 30 * Time.deltaTime);
        }
    }
}


/*float dist = navMeshAgent.remainingDistance;
        if (dist != Mathf.Infinity && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance == 0)

        {

        }
        */
