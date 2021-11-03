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
    [SerializeField] GameObject sabotage1Volume;

    public float sabotageTime;
    // Start is called before the first frame update
    public void StartAbility()
    {
        playerMov = GetComponent<playerMovement>();
        playerMov.speed = playerMov.speed / speedChangeFactor;
        playerMov.gravity = playerMov.gravity / gravityChangeFactor;
        camerarotation.mouseSensitivity = camerarotation.mouseSensitivity / sensitivityChangeFactor;
        sabotage1Volume.SetActive(true);
        Invoke(nameof(Reset), sabotageTime);
    }

    private void Reset()
    {
        sabotage1Volume.SetActive(false);
        playerMov.speed = playerMov.speed * speedChangeFactor;
        playerMov.gravity = playerMov.gravity * gravityChangeFactor;
        camerarotation.mouseSensitivity = camerarotation.mouseSensitivity * sensitivityChangeFactor;
    }
}
