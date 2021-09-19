
using UnityEngine;

public class damages : MonoBehaviour
{
    public float health = 50f;

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
