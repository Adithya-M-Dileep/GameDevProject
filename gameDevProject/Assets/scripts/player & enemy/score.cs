using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    //public static score Instance;
    [SerializeField] TMP_Text scoreText;
    public static int currentScore = 0;


    private void Update()
    {
        scoreText.text = currentScore.ToString();
    }

    public int curretScoreReturn()
    {
        return currentScore;
    }
}
