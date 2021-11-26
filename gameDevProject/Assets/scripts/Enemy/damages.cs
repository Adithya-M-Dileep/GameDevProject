
using UnityEngine;

public class damages : MonoBehaviour
{
    public float health = 50f;
    public int scoreGained = 100;


    //sound
    public AudioSource audioSource;
    public AudioClip bulletHitClip;
    public void takeDamage(float amount)
    {
        health -= amount;
        audioSource.PlayOneShot(bulletHitClip);
        if (health <= 0)
        {

            audioSource.Play();
            score.currentScore += scoreGained;
            Destroy(gameObject);
        }
    }
}
