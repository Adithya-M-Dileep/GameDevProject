using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class sabotage2Poison : MonoBehaviour
{
    
    float currentTime;
    public float startingMinute;
    public float damageInterval;
    public float damageAmount;
    public float damageRadius;

    void Start()
    {
        currentTime = startingMinute*60;
        DecreaseLife();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime < 0)
        {
           Destroy(gameObject);
        }
        
    }
    void DecreaseLife()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (Collider nearObject in colliders)
        {
            if (nearObject.CompareTag("Player"))
            {
                healthStatus healthOfPlayer = nearObject.transform.GetComponent<healthStatus>();
                healthOfPlayer.takeDamage(damageAmount);
            }
        }
        
        Invoke(nameof(DecreaseLife), damageInterval);
    }
}
