using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    float mousSensitivity = 100f;
    Transform playerBody;
    float xrotation = 0f;
    float startyPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = GameObject.FindGameObjectWithTag("Player").transform;
        //hides cursor from player;
        startyPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        #region Look Around The Scene
        float mouseX = Input.GetAxis("Mouse X") * mousSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousSensitivity * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        #endregion

    }

    #region Crouch stuff
    public void IsCrouchingCamMovement()
    {

        transform.position = new Vector3(transform.position.x, startyPos / 2f, transform.position.z);
    }
    public void IsNotCrouchingAnymore()
    {
        transform.position = new Vector3(transform.position.x, startyPos, transform.position.z);
    }
    #endregion
}
