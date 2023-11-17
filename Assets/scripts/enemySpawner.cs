using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject deerPrefab;
    public GameObject bearPrefab;
    public GameObject foxPrefab;

    int deerCount;
    int foxCount;
    int bearCount;


    private GameObject[] deers = null;
    private GameObject[] foxes = null;
    private GameObject[] bears = null;

    private void Start()
    {
        deerCount = PlayerPrefs.GetInt("deerCount", 0);
        foxCount = PlayerPrefs.GetInt("foxCount", 0);
        bearCount = PlayerPrefs.GetInt("bearCount", 0);

        spawnEnemys(deerCount, foxCount, bearCount);
    }


    public void spawnEnemys(int deerCount, int foxCount, int bearCount) //given amount of each enemy to spawn, spawn them randomly across the map, (not inside of colliders)
    {
        for(int i = 0; i < deerCount; i++) //deer spawner
        {
            int xPos = Random.Range(-34, 72);
            int yPos = Random.Range(-45, 16);

            Instantiate(deerPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            Debug.Log("Spawned deer");
        }

        for (int i = 0; i < foxCount; i++) //fox spawner
        {
            int xPos = Random.Range(-34, 72);
            int yPos = Random.Range(-45, 16);

            Instantiate(foxPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            Debug.Log("Spawned fox");
        }

        for (int i = 0; i < bearCount; i++) //bear spawner
        {
            int xPos = Random.Range(-34, 72);
            int yPos = Random.Range(-45, 16);

            Instantiate(bearPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);

            Debug.Log("Spawned bear");
        }


    }


    



}
