using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    //public static score Instance;
    [SerializeField] TMP_Text scoreText;
    public static int currentScore = 0;

    // private void Awake()
    // {
    //    if (Instance)
    ///     {
    //       Destroy(gameObject);
    //        return;
    //    }
    //     DontDestroyOnLoad(gameObject);
    //     Instance = this;
    //}
    //public void ScoreIncrease(int newScore)
    //{
    //    currentScore += newScore;
    //     scoreText.text = currentScore.ToString();
    //}

    // public void scoreDecrease(int decreaseInScore)
    // {
    //    currentScore -= decreaseInScore;
    //    scoreText.text = currentScore.ToString();
    // }

    private void Update()
    {
        scoreText.text = currentScore.ToString();
    }

}
