using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLister : MonoBehaviour
{
    private GoalSpawner pointsCList;

    void Start()
    {   
        pointsCList = GameObject.FindGameObjectWithTag("Grid").GetComponent<GoalSpawner>();
        pointsCList.spawnPointsC.Add(this.gameObject);
    }
}
