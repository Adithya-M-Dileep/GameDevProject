using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class usernameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView playerPV;
    [SerializeField] TMP_Text Text;

    private void Start()
    {
        if(playerPV.IsMine)
        {
            gameObject.SetActive(false);
        }
        Text.text = playerPV.Owner.NickName;
    }
}
