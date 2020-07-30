using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    public bool isCrouching;
    LookAround lookAround;

    public GameObject torchObj;
    bool toggleTorch = false;
    public float maxTorchTime = 60;
    float remainingTorchTime;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundCheck = GameObject.FindGameObjectWithTag("groundCheck").transform;
        lookAround = FindObjectOfType<LookAround>();
        remainingTorchTime = maxTorchTime;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        #region WASDMovement & Jump
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
        #endregion

        #region Crouch
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
        #endregion

        #region Torch
        if (Input.GetMouseButtonDown(1))
        {
            if (remainingTorchTime >= 0)
            {
                toggleTorch = !toggleTorch;
                torchObj.SetActive(toggleTorch);
            }
        }

        if (toggleTorch == true)
        {
            //subtract torch time
            //if torch =5seconds left flicker
            //switch torch off
            remainingTorchTime -= Time.deltaTime;

            if (remainingTorchTime <= 1.5 && remainingTorchTime > 0.3)
            {
                StartCoroutine(TorchFlicker());
            }


        }
        if (remainingTorchTime <= 0)
        {
            toggleTorch = false;
            torchObj.SetActive(toggleTorch);
        }
        #endregion

    }


    IEnumerator TorchFlicker()
    {
        torchObj.SetActive(false);
        yield return new WaitForSeconds(0.02f);
        torchObj.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        torchObj.SetActive(false);
        yield return new WaitForSeconds(0.02f);
        torchObj.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        torchObj.SetActive(false);
        yield return new WaitForSeconds(0.02f);
        torchObj.SetActive(true);
    }
}