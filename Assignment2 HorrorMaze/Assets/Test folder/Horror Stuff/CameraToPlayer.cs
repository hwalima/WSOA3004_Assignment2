using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    public Transform player;
    float heading = 0;
    float tilt = 10;
    float camDist = 8.5f;
    float playerHeight = 1f;

    void Update()
    {
        DoZom();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        tilt += Input.GetAxis("Mouse Y") * Time.deltaTime * 180;

        tilt = Mathf.Clamp(tilt, 10, 50);

        transform.rotation = Quaternion.Euler(tilt, heading, 0);

        transform.position = player.position - transform.forward * camDist + Vector3.up*playerHeight;
    }
    void DoZom()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView++;
        }
    }
}
