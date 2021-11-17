using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    public Text Name;
    public Text winnerTag;
    PhotonView pv;

    int ownScore;
    string ownName;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    public void ShowWinner()
    {
        ownScore = score.currentScore;
        ownName = PhotonNetwork.NickName;
        pv.RPC("ScoreAndName", RpcTarget.Others,ownScore,ownName);
    }

    [PunRPC]
    public void ScoreAndName(int othersScore,string othersName)
    {
        if (ownScore < othersScore)
            WinnerDisplay(othersName);
        else if (othersScore < ownScore)
            WinnerDisplay(ownName);
        else
        {
            winnerTag.text = "";
            WinnerDisplay("TIE");
        }
    }

    public void WinnerDisplay(string winnerName)
    {
        Name.text = winnerName;
    }
}
