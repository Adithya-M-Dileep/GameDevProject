using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class playerManager : MonoBehaviour
{
    PhotonView PV;
    GameObject controller;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();        
        }
    }

    void CreateController()
    {
       Transform spawnpoint = SpawnManagers.instance.GetSpawnPoint();
       controller= PhotonNetwork.Instantiate(Path.Combine("photonPrefab", "PlayerController"), spawnpoint.position,spawnpoint.rotation,0,new object[] { PV.ViewID });
    }
    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
