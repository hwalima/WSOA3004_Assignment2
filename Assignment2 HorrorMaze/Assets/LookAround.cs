using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    float mousSensitivity = 100f;
    Transform playerBody;
    float xrotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = GameObject.FindGameObjectWithTag("Player").transform;
        //hides cursor from player;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousSensitivity * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
