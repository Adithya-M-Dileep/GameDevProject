using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageAbilities : MonoBehaviour
{
    [SerializeField] int ability1Cost = 10;
    [SerializeField] int ability2Cost = 20;
    [SerializeField] int ability3Cost = 30;

    //score scoreObj;
    int current = 0;
   // private void Start()
   // {
   //     scoreObj = GetComponent<score>();
   // }
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if(score.currentScore >= ability1Cost)
            {
                Debug.Log("Ability 1 activated");
                //scoreObj.scoreDecrease(ability1Cost);
                score.currentScore -= ability1Cost;
            }
            else
            {
                Debug.Log("Not enough Score");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (score.currentScore >= ability2Cost)
            {
                Debug.Log("Ability 2 activated");
                //scoreObj.scoreDecrease(ability2Cost);
                score.currentScore -= ability2Cost;
            }
            else
            {
                Debug.Log("Not enough Score");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (score.currentScore >= ability3Cost)
            {
                Debug.Log("Ability 3 activated");
                //scoreObj.scoreDecrease(ability3Cost);
                score.currentScore -= ability3Cost;
            }
            else
            {
                Debug.Log("Not enough Score");
            }
        }
    }
}
