using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
   [SerializeField]
   public List<GameObject> spawnPointsC;

   public static GoalSpawner goalS;

   public GameObject goal;
   private float timer = 10f;
   private bool goalBe = false;

    private void Awake()
    {
        goalS = this;
    }

   public void Update()
   {
      timer -= Time.deltaTime;

      if (timer <= 0 && goalBe == false )
      {
         GoalBe();
      }
   }

   public void GoalBe()
   {
      var spawnIndex = Random.Range(0, spawnPointsC.Count);
      var randomC = spawnPointsC[spawnIndex].transform.position;

      Instantiate(goal, randomC, Quaternion.identity);
      
      goalBe = true;
      Debug.Log(spawnIndex);
   }

   public void GoalNBe()
   {
      goalBe = false;
   }
}