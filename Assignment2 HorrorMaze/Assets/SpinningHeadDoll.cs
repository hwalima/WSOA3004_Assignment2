using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpinningHeadDoll : MonoBehaviour
{
    Transform player;
    PlayerMovement playerMovement;

    public float radiusOfAwareness = 4f;
    public Transform headObj;

    public float chaseRadius = 3f;
    bool isCHasingPlayer;
    NavMeshAgent navMeshAgent;

    float collectableSoulStoppingDIstance = 5.5f;

    List<GameObject> noOfSoulsInScene = new List<GameObject>();
    int rand;
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
        for (var i = noOfSoulsInScene.Count - 1; i > -1; i--)
        {
            if (noOfSoulsInScene[i] == null)
            {
                noOfSoulsInScene.RemoveAt(i);
                rand = Random.Range(0, noOfSoulsInScene.Count);
            }
        }

        if (Vector3.Distance(player.position, transform.position) < radiusOfAwareness)
        {
            headObj.transform.LookAt(player);
        }
        else
        {
         //   headObj.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + 180, player.transform.position.z));
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

                }
                else if (playerMovement.isCrouching)
                {
                    //continueOnWith Movement
                }
            }

            if (isCHasingPlayer)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
        }
        else if (Vector3.Distance(player.position, transform.position) > chaseRadius)
        {
            isCHasingPlayer = false;
            navMeshAgent.SetDestination(noOfSoulsInScene[rand].transform.position);
            navMeshAgent.stoppingDistance = collectableSoulStoppingDIstance;


            if (Vector3.Distance(noOfSoulsInScene[rand].transform.position, transform.position) <= collectableSoulStoppingDIstance)
            {
                rand = Random.Range(0, noOfSoulsInScene.Count);
                navMeshAgent.SetDestination(noOfSoulsInScene[rand].transform.position);
                navMeshAgent.stoppingDistance = collectableSoulStoppingDIstance;
            }

        }
        if (navMeshAgent.destination == null)
        {
            rand = Random.Range(0, noOfSoulsInScene.Count);
            navMeshAgent.SetDestination(noOfSoulsInScene[rand].transform.position);
            navMeshAgent.stoppingDistance = collectableSoulStoppingDIstance;
        }
    }
}
