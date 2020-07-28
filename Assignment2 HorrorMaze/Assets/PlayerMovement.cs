using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     CharacterController characterController;
    public float speed=12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight=3f;

   public bool isCrouching;
    LookAround lookAround;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundCheck = GameObject.FindGameObjectWithTag("groundCheck").transform;
        lookAround = FindObjectOfType<LookAround>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isCrouching)
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


            Vector3 move = transform.right * x + transform.forward * z;
            characterController.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            lookAround.IsCrouchingCamMovement();
            isCrouching = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lookAround.IsNotCrouchingAnymore();
            isCrouching = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //GameOver
            
        }
    }
}
