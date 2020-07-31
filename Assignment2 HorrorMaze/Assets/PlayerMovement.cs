using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider torchSlider;

    Actions actionsscr;
    GameManager gameManager;

   public  bool isTouchingTombstone;

    #region Homolang and his sound scripts
    public bool walking=false;
    public bool jumping=false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundCheck = GameObject.FindGameObjectWithTag("groundCheck").transform;
        lookAround = FindObjectOfType<LookAround>();
        remainingTorchTime = maxTorchTime;
        actionsscr = FindObjectOfType<Actions>();
        gameManager = FindObjectOfType<GameManager>();
        torchSlider.maxValue = maxTorchTime;
        torchSlider.value = maxTorchTime;

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

            if(velocity.x>0.2f || velocity.z > 0.2f)
            {
                walking = true;
            }
            else
            {
                walking = false;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                StartCoroutine(JumpSound());
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
            torchSlider.value = remainingTorchTime;

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

        if (gameManager.theGameIsOver)
        {
            this.enabled = false;
        }
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

    IEnumerator JumpSound()
    {
        jumping = true;
        yield return new WaitForSeconds(0.5f);
        jumping = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {

            gameManager.GameOver();
        }
        if (hit.gameObject.tag == "Tombstone")
        {
            isTouchingTombstone = true;
        }
        else
        {
            isTouchingTombstone = false;
        }
    }
    
}