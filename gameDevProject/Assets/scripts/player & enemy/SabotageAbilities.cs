using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SabotageAbilities : MonoBehaviour
{
    [SerializeField] int ability1Cost = 10;
    [SerializeField] int ability2Cost = 20;
    [SerializeField] int ability3Cost = 30;

    
    int current = 0;

    PhotonView pv;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        //pv = PhotonView.Get(this);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(score.currentScore >= ability1Cost)
            {
                Debug.Log("Ability 1 activated");
                pv.RPC("ability1", RpcTarget.Others);
                score.currentScore -= ability1Cost;
            }
            else
            {
                Debug.Log("Not enough Score");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (score.currentScore >= ability2Cost)
            {
                Debug.Log("Ability 2 activated");
                pv.RPC("ability2", RpcTarget.Others);
                score.currentScore -= ability2Cost;
            }
            else
            {
                Debug.Log("Not enough Score");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (score.currentScore >= ability3Cost)
            {
                Debug.Log("Ability 3 activated");
                pv.RPC("ability3", RpcTarget.Others);
                score.currentScore -= ability3Cost;
            }
            else
            {
                Debug.Log("Not enough Score");
            }
        }
    }

    [PunRPC]
    void ability1()
    {
        Debug.Log("Ability 1 completed");
        //sabotage abiltiy 1
    }
    [PunRPC]
    void ability2()
    {
        Debug.Log("Ability 2 completed");
        //sabotage abiltiy 1
    }
    [PunRPC]
    void ability3()
    {
        Debug.Log("Ability 3 completed");
        //sabotage abiltiy 1
    }

}
