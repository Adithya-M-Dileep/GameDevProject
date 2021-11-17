using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class score : MonoBehaviour
{
    //public static score Instance;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Text otherPlayerScore;
    public static int currentScore = 0;

    PhotonView pv;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        currentScore = Mathf.Clamp(currentScore, 0, 5000);
        scoreText.text = currentScore.ToString();
        pv.RPC("OtherplayerScoreUpdate", RpcTarget.Others, currentScore);
    }

    [PunRPC]
    void OtherplayerScoreUpdate(int OtherPScore)
    {
        otherPlayerScore.text = OtherPScore.ToString();
    }
}
