using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthStatus : MonoBehaviour
{
    [SerializeField]Image healthBar;

    float maxHealth = 100;
    public float currentHealth { get; private set; }
    public float damagePerShot = 10f;
    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            takeDamage(10);
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
        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        //respawn
    }

}