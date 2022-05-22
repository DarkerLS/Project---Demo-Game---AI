using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager scoreM;

    public Text scoreT1;
    public int scoreN1 = 0;

    public Text scoreT2;
    public int scoreN2 = 0;
    
    private void Awake()
    {
        scoreM = this;
    }
    
    void Start()
    {
        scoreT1.text = "P1 " + scoreN1.ToString();
        scoreT2.text = "AI " + scoreN2.ToString();
    }


    public void AddPointP1()
    {
        scoreN1 += 1;
        scoreT1.text = scoreT1.text = "P1 " + scoreN1.ToString();
    }

    public void AddPointAI()
    {
        scoreN2 += 1;
        scoreT2.text = scoreT2.text = "AI " + scoreN2.ToString();
    }


    public void TakePointP1()
    {
        scoreN1 -= 1;
        scoreT1.text = scoreT1.text = "P1 " + scoreN1.ToString();
    }

    public void TakePointAI()
    {
        scoreN2 -= 1;
        scoreT2.text = scoreT2.text = "AI " + scoreN2.ToString();
    }
}
