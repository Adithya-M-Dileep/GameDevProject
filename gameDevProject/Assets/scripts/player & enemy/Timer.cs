using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingMinute;
    public Text currentTimeText;

    [SerializeField] GameObject endPanel;
    [SerializeField] Winner _winner;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingMinute * 60;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime < 0)
        {
            endPanel.SetActive(true);
            _winner.ShowWinner();
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
