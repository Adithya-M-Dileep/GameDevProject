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
    public TrailRenderer bulletTrails;
    public Transform trailStart;
    public GameObject impactEffect;
    public float impactForce = 75f;
    private bool isReloading = false;

    public float nextTimeToFire = 0f;

    //sound
    public AudioSource audioSource;
    public AudioClip FireClip;
    public AudioClip reloadClip;

    //animation
    public Animator animator;
    private void Start()
    {
        currentBullet = maxBullets;
    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("reloading", false);
    }
    void Update()
    {
        if (isReloading)
            return;
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {

                nextTimeToFire = Time.time + 1f / fireRate;
                shoot();
            
        }
        if (currentBullet<=0||Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        
    }

    void shoot()
    {
        audioSource.PlayOneShot(FireClip);
        currentBullet--;
        muzzleFlash.Play();
        RaycastHit hit;
        var traces = Instantiate(bulletTrails, trailStart.position, Quaternion.identity);
        traces.AddPosition(trailStart.position);
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
            traces.transform.position = hit.point;
            GameObject impactGo= Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 1f);
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;
        audioSource.PlayOneShot(reloadClip);
        Debug.Log("reloading");
        animator.SetBool("reloading", true);
        yield return new WaitForSeconds(reloadTime-0.25f);
        animator.SetBool("reloading", false);
        yield return new WaitForSeconds(0.25f);
        currentBullet = maxBullets;
        isReloading = false;
    }
}
