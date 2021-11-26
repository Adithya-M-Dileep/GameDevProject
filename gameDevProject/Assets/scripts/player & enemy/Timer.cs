using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingMinute;
    public Text currentTimeText;
    public int maxScore;

    bool win = false;
    PhotonView pv;

    [SerializeField] GameObject endPanel;
    [SerializeField] Winner _winner;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        currentTime = startingMinute * 60;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        if ((currentTime < 0) ||(score.currentScore>=maxScore)||win)
        {
            endPanel.SetActive(true);
            Cursor.visible = true;
            pv.RPC("GameEnd", RpcTarget.Others);
            _winner.ShowWinner();
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
    [PunRPC]
    void GameEnd()
    {
        win = true;
    }

}
