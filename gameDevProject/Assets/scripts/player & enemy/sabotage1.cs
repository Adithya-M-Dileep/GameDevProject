using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabotage1 : MonoBehaviour
{
    [SerializeField] float speedChange;
    [SerializeField] float sensitivityChange;

    float oldSpeed;
    float oldSensitivity;

    public cameraRotation camerarotation;
    playerMovement playerMov;
    [SerializeField] GameObject sabotage1Volume;

    public float sabotageTime;
    // Start is called before the first frame update
    public void StartAbility()
    {
        playerMov = GetComponent<playerMovement>();
        oldSpeed = playerMov.speed;
        oldSensitivity = camerarotation.mouseSensitivity;

        playerMov.speed = speedChange;
        camerarotation.mouseSensitivity = sensitivityChange;
        sabotage1Volume.SetActive(true);
        Invoke(nameof(Reset), sabotageTime);
    }

    private void Reset()
    {
        sabotage1Volume.SetActive(false);
        playerMov.speed = oldSpeed;
        camerarotation.mouseSensitivity = oldSensitivity;
    }
}
