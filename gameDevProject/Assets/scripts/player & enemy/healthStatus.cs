﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthStatus : MonoBehaviour
{
    [SerializeField]Image healthBar;

    float maxHealth = 100;
    public float currentHealth { get; private set; }
    public float damagePerShot = 10f;
    public int decreaseInScorePerDeath;
    public float lowerYvalue;

    bool dead = false;

    [SerializeField] Transform spawnpoint;
    [SerializeField] GameObject DeadUi;
    [SerializeField] GameObject deathVolume;
    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            takeDamage(10);
        if (transform.position.y < lowerYvalue && !dead)
            takeDamage(100);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
            takeDamage(damagePerShot);
    }
    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, 100f);
        healthBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0 && !dead)
        {

            transform.position = spawnpoint.position;
            DeadUi.SetActive(true);
            deathVolume.SetActive(true);
            dead = true;
            Invoke(nameof(Die), 5f);
        } 
    }

    void Die()
    {
        DeadUi.SetActive(false);
        deathVolume.SetActive(false);
        currentHealth = 100;
        healthBar.fillAmount = 1;
        transform.position = spawnpoint.position;
        score.currentScore -= decreaseInScorePerDeath;
        dead = false;
        Physics.SyncTransforms();
    }

}