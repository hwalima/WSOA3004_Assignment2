using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    public AudioSource pickup;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameManager.totalCOllected++;
            //gameManager.ActivateShowOrbsText();
            Destroy(transform.parent.gameObject);
            pickup.Play();
        }
    }


}
