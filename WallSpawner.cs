using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallToSpawn;

    private bool GetWall()
    {
        float random = Random.Range(0f, 1f);
        
        if(random <= 0.125f)
        {
            Instantiate(wallToSpawn, transform.position, transform.rotation);
            return true;
        }
        else
        {
            return false;
        }

    }

    void Start()
    {
        Invoke("GetWall", 0.5f);
    }

}