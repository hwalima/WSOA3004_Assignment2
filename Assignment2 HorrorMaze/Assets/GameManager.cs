using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int noOfSoulsToCOllect = 3;
    public int totalCOllected = 0;
    public GameObject []collectableSoulThing;

    public GameObject youWonPanel;
    public GameObject youLosepanel;
    public int noOfSpiderThingEnemies = 6;
    public int noOfRotatingHeadEnemies = 6;

    public GameObject spiderThingEnemies;
    public GameObject spinningHeadEnemies;


    public Text orbsRemainingText;


    public List<Vector3> possibleOrbSpawnPoints = new List<Vector3>();
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnCollectableSouls();
        SpawnSpiderthings();
        SpawnSpinningHeadEnemies();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public bool theGameIsOver=false;
    private void Start()
    {
        // StartCoroutine(ShowHowManyOrbsLeft());
        theGameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (totalCOllected == noOfSoulsToCOllect )
        {
            if (playerMovement.isTouchingTombstone == true)
            {
                youWonPanel.SetActive(true);
                theGameIsOver = true;
            }
        }
        orbsRemainingText.text = totalCOllected + "/" + noOfSoulsToCOllect.ToString();
    }

    void SpawnCollectableSouls()
    {

        for (int i = 0; i < noOfSoulsToCOllect; i++)
        {
            int choosePossibleSpawnPoint = Random.Range(0, possibleOrbSpawnPoints.Count);
            Instantiate(collectableSoulThing[i], possibleOrbSpawnPoints[choosePossibleSpawnPoint], Quaternion.identity);
            possibleOrbSpawnPoints.Remove(possibleOrbSpawnPoints[choosePossibleSpawnPoint]);
        }
    }
    void SpawnSpiderthings()
    {
        for (int i = 0; i < noOfSpiderThingEnemies; i++)
        {
            float randomx = Random.Range(25, 100);
            float randomz = Random.Range(20, 110);
            Instantiate(spiderThingEnemies, new Vector3(randomx, 2, randomz), Quaternion.identity);
        }
    }

    void SpawnSpinningHeadEnemies()
    {
        for (int i = 0; i < noOfSpiderThingEnemies; i++)
        {
            float randomx = Random.Range(1, 100);
            float randomz = Random.Range(20, 110);
            Instantiate(spinningHeadEnemies, new Vector3(randomx, 2, randomz), Quaternion.identity);
        }
    }
    public void GameOver()
    {
        youLosepanel.SetActive(true);
        theGameIsOver = true;
    }

    public void ActivateShowOrbsText()
    {
       // StartCoroutine(ShowHowManyOrbsLeft());
    }

    IEnumerator ShowHowManyOrbsLeft()
    {
        orbsRemainingText.gameObject.SetActive(true);
        orbsRemainingText.text = totalCOllected + "/" + noOfSoulsToCOllect.ToString();
        yield return new WaitForSeconds(6f);
        orbsRemainingText.gameObject.SetActive(false);
    }
}