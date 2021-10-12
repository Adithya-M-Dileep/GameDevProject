using UnityEngine;

public class grenade : MonoBehaviour
{
    public float delay = 3f;
    float countDown;
    public float blastradius=5f;
    public float blastDamage = 100f;

    public GameObject explosionEffect;

    bool hasExploded = false;


    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if(!hasExploded && countDown <= 0)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        GameObject explosion=(GameObject) Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastradius);
        foreach(Collider nearObject in colliders)
        {
            if(nearObject.CompareTag("Enemy"))
            {
                damages enemy = nearObject.transform.GetComponent<damages>();
                enemy.takeDamage(blastDamage);
            }
        }
        Destroy(explosion, 2f);
        Destroy(gameObject);
    }
}
