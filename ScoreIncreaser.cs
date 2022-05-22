using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "P1")
        {
            ScoreManager.scoreM.AddPointP1();
            Destroy(gameObject);
            GoalSpawner.goalS.GoalNBe();
        }

        if (other.GetComponent<Collider>().tag == "AI")
        {
            ScoreManager.scoreM.AddPointAI();
            Destroy(gameObject);
            GoalSpawner.goalS.GoalNBe();
        }
    }
}
