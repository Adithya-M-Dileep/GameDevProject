
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public float mouseSensitivity =100f;
    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xmove = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float ymove = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= ymove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xmove);

    }
}
