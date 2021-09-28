using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    Rigidbody rb;

    public float speed = 70f;

    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void seek(Transform _target)
    {
        target = _target;
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        Invoke(nameof(DestroyGO), 2);
    }
    
    void DestroyGO()
    {
        Destroy(gameObject);
    }
}
