using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDecreaser : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "P1")
        {
            ScoreManager.scoreM.TakePointP1();
        }

        if (other.GetComponent<Collider>().tag == "AI")
        {
            ScoreManager.scoreM.TakePointAI();
        }
    }
}
