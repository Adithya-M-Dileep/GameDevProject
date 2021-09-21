
using UnityEngine;

public class damages : MonoBehaviour
{
    public float health = 50f;
    public int scoreGained = 100;

    //score scoreObj;
   // private void Start()
   // {
   //     scoreObj = GetComponent<score>();
   // }
    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //  scoreObj.ScoreIncrease(scoreGained);
            score.currentScore += scoreGained;
            Destroy(gameObject);
        }
    }
}
