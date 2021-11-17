using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SabotageAbilities : MonoBehaviour
{
    [SerializeField] int ability1Cost = 10;
    [SerializeField] int ability2Cost = 20;
    [SerializeField] int ability3Cost = 30;


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
        //sabotage abiltiy 1

        sabotage3 Sabotage3 = GetComponent<sabotage3>();
        Sabotage3.startAbility();

    }
    [PunRPC]
    void ability2()
    {

        sabotage1 Sabotage1 = GetComponent<sabotage1>();
        Sabotage1.StartAbility();

        //sabotage abiltiy 1
    }
    [PunRPC]
    void ability3()
    {
        //sabotage abiltiy 1
        sabotage2 Sabotage2 = GetComponent<sabotage2>();
        Sabotage2.StartAbility();
    }

}
