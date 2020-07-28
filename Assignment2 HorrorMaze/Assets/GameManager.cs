using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int noOfSoulsToCOllect=5;
    public int totalCOllected = 0;
    public GameObject collectableSoulThing;

   public GameObject youWonPanel;
    public GameObject youLosepanel;
   public int noOfSpiderThingEnemies=6;
    public int noOfRotatingHeadEnemies=6;

    public GameObject spiderThingEnemies;
    public GameObject spinningHeadEnemies;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnCollectableSouls();
        SpawnSpiderthings();
        SpawnSpinningHeadEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalCOllected == noOfSoulsToCOllect)
        {
            youWonPanel.SetActive(true);
        }
    }

    void SpawnCollectableSouls()
    {
        for (int i = 0; i < noOfSoulsToCOllect; i++)
        {
            float randomx = Random.Range(1, 100);
            float randomz = Random.Range(-0,110);
            Instantiate(collectableSoulThing, new Vector3(randomx, 2, randomz), Quaternion.identity);
        }
    }
    void SpawnSpiderthings()
    {
        for (int i = 0; i < noOfSpiderThingEnemies; i++)
        {
            float randomx = Random.Range(1, 100);
            float randomz = Random.Range(-0, 110);
            Instantiate(spiderThingEnemies, new Vector3(randomx, 2, randomz), Quaternion.identity);
        }
    }

    void SpawnSpinningHeadEnemies()
    {
        for (int i = 0; i < noOfSpiderThingEnemies; i++)
        {
            float randomx = Random.Range(1, 100);
            float randomz = Random.Range(-0, 110);
            Instantiate(spinningHeadEnemies, new Vector3(randomx, 2, randomz), Quaternion.identity);
        }
    }
    public void GameOver()
    {
        youLosepanel.SetActive(true);
    }
}
