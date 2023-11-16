using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject deerPrefab;
    public GameObject bearPrefab;
    public GameObject foxPrefab;
    public void spawnEnemys(int deerCount, int foxCount, int bearCount) //given amount of each enemy to spawn, spawn them randomly across the map, (not inside of colliders)
    {
        for(int i = 0; i < deerCount; i++) //deer spawner
        {
            int xPos = Random.Range(-34, 98);
            int yPos = Random.Range(-53, 18);

            Instantiate(deerPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            Debug.Log("Spawned deer");
        }

        for (int i = 0; i < foxCount; i++) //fox spawner
        {
            int xPos = Random.Range(-34, 98);
            int yPos = Random.Range(-53, 18);

            Instantiate(foxPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            Debug.Log("Spawned fox");
        }

        for (int i = 0; i < bearCount; i++) //bear spawner
        {
            int xPos = Random.Range(-34, 98);
            int yPos = Random.Range(-53, 18);

            Instantiate(bearPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);

            Debug.Log("Spawned bear");
        }
    }
}
