using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeThrowing : MonoBehaviour
{
    public float throwForce =50f;
    public GameObject grenadePrefab;
    public Transform throwPoint;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            throwGrenade();
        }
    }
    void throwGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);
    }
}
