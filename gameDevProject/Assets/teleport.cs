using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject player;
    public Transform teleportPoint;
    void Start()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("teleport");
            player.transform.position = teleportPoint.position;
            
        
        }
    }
}
