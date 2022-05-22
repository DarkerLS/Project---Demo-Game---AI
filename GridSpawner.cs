using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject[] floor;
    public int gridX;
    public int gridZ;
    public float gridOffset = 2.5f;
    public Vector3 gridO = Vector3.zero;
   

    void Awake()
    {
        Invoke("GetFloor", 0.1f);
    }

    void GetFloor()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridOffset, 0, z * gridOffset) + gridO;
                AndSpawn(spawnPosition, Quaternion.Euler(0,0,90));
            }
        }
    }

    void AndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, floor.Length);
        GameObject clone = Instantiate(floor[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
