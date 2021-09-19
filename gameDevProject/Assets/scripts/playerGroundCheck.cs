using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGroundCheck : MonoBehaviour
{
    playerMovements playerController;

    private void Awake()
    {
        playerController = GetComponent<playerMovements>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
            return;
       // playerController.setGroundedState(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
            return;
       // playerController.setGroundedState(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
            return;
        //playerController.setGroundedState(true);
    }
}
