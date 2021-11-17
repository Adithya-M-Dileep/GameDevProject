using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class loadRoom : MonoBehaviour
{
    public GameObject endgame;
    public void RoomMenu()
    {
        //Destroy(GameObject.Find("PhotonMono"));
        //Destroy(GameObject.Find("roomManager"));
        //PhotonNetwork.LeaveRoom();
        //while (PhotonNetwork.InRoom)
            //continue;
        //PhotonNetwork.LeaveLobby();
        //while (PhotonNetwork.InLobby)
            //continue;
        //PhotonNetwork.Disconnect();
        //while (PhotonNetwork.IsConnected)
            //continue;

        //SceneManager.LoadScene(0);

        Application.Quit();
        //Application.LoadLevel(0);
    }

}
