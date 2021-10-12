using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    Rigidbody rb;

    public float speed = 32f;

    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void seek()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse) ;
        Invoke(nameof(DestroyGO), 2);
    }
    
    void DestroyGO()
    {
        Destroy(gameObject);
    }
}
