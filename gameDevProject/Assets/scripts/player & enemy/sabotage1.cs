using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabotage1 : MonoBehaviour
{
    [SerializeField] float speedChangeFactor;
    [SerializeField] float gravityChangeFactor;
    [SerializeField] float sensitivityChangeFactor;

    public cameraRotation camerarotation;
    playerMovement playerMov;

    public float sabotageTime;
    // Start is called before the first frame update
    void Start()
    {
        playerMov = GetComponent<playerMovement>();
        playerMov.speed = playerMov.speed / speedChangeFactor;
        playerMov.gravity = playerMov.gravity / gravityChangeFactor;
        camerarotation.mouseSensitivity = camerarotation.mouseSensitivity / sensitivityChangeFactor;
        Invoke(nameof(Reset), sabotageTime);
    }

    private void Reset()
    {
        playerMov.speed = playerMov.speed * speedChangeFactor;
        playerMov.gravity = playerMov.gravity * gravityChangeFactor;
        camerarotation.mouseSensitivity = camerarotation.mouseSensitivity * sensitivityChangeFactor;
    }
}
