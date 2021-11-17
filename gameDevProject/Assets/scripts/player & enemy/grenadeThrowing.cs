using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeThrowing : MonoBehaviour
{
    public float throwForce =50f;
    public GameObject grenadePrefab;
    public Transform throwPoint;
    public int maxGrenadeCount = 5;
    float currentGrenadeCount;
    public float grenadeRefillTime;
    bool isRefilling = false;

    private void Start()
    {
        currentGrenadeCount = maxGrenadeCount;
    }
    private void Update()
    {
        if (isRefilling)
            return;
        if(Input.GetKeyDown(KeyCode.G))
        {
            throwGrenade();
            currentGrenadeCount--;
        }
        if (currentGrenadeCount <= 0)
        {
            StartCoroutine(Refill());
            return;
        }
    }
    void throwGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);
    }
    IEnumerator Refill()
    {
        isRefilling = true;
        yield return new WaitForSeconds(grenadeRefillTime);
        currentGrenadeCount = maxGrenadeCount;
        isRefilling = false;

    }
}
