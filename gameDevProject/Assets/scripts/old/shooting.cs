using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour
{
    public Camera fpsCam;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public int maxBullets = 10;
    private int currentBullet;
    public float reloadTime=2f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 75f;
    private bool isReloading = false;

    public float nextTimeToFire = 0f;

    private void Start()
    {
        currentBullet = maxBullets;
    }
    void Update()
    {
        if (isReloading)
            return;
        if(currentBullet<=0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButton("Fire1")&&Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();
        }
    }

    void shoot()
    {
        currentBullet--;
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            damages gotHit = hit.transform.GetComponent<damages>();
            if(gotHit!=null)
            {
                gotHit.takeDamage(damage);
            }
            if(hit.rigidbody!=null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGo= Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 1f);
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");
        yield return new WaitForSeconds(reloadTime);
        currentBullet = maxBullets;
        isReloading = false;
    }
}
