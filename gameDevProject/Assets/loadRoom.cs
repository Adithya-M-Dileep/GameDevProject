using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class loadRoom : MonoBehaviour
{
    public void RoomMenu()
    {
        PhotonNetwork.LoadLevel(0);    }
}
