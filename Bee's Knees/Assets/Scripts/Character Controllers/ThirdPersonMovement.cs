﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    #region Object Reference Variables
    public CharacterController controller;
    public Transform cam;
    public GameObject EubieObject;
    public GameObject DDObject;
    public Animator anim, Duckanim;
    #endregion

    #region Movement Variables
    public float speed = 1f;
    public float jumpForce = 1f;
    public float gravityScale = 1f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private float horizontal;
    private float vertical;
    private bool onGround;
    RaycastHit hit;
    #endregion

    #region Character Switching Values
    private enum Characters
    {
        Eubie,
        DD
    }
    private Characters currentChar;
    #endregion

    #region Jump/Gravity Test Values
    private Vector3 playerVelocity;
    private bool notGrounded;
    private float playerSpeed = 2.0f;
    public float jumpHeight = 5.0f;
    private float gravityValue = -9.81f * 10f;
    #endregion

    bool isInDialogue = false;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        #region Initial currentChar value
        if (EubieObject.activeSelf == true)
        {
            currentChar = Characters.Eubie;
        }

        else if (DDObject.activeSelf == true)
        {
            currentChar = Characters.DD;
        }

        else
        {
            EubieObject.SetActive(true);
            currentChar = Characters.Eubie;
        }
        #endregion
    }

    // Update is called once per frame
    void Update()

    {

        if (isInDialogue) return;
        //Debug.Log("onGround: " + IsGrounded());
        OnGround();
        Debug.Log(onGround);
        /*
         * TODO:
         * Create a custom character controller (again) that allows the use of rigid bodies
         * The float values used here are just -1, 0, and 1, which I can easily simulate
         * with the boolean Input.GetKeyDown. This will allow me to keep the camera
         * turning functionality, while using my own character controller, and have
         * customizable buttons
         */
        #region Character Turning and Movement
        /* 
         float horizontal = BKController.horizontal;
         float vertical = BKController.vertical;
         Debug.Log("Horizontal: " + horizontal);
         Debug.Log("Vertical: " + vertical);*/
        //notGrounded = !controller.isGrounded;
        //Debug.Log(notGrounded);
        if (onGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if (Input.GetButtonDown("Jump") && onGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //floats for animator
        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);
        Duckanim.SetFloat("horizontal", horizontal);
        Duckanim.SetFloat("vertical", vertical);

        if (Input.GetKey(KeyCode.Space))
        {
            //Makes Eubie&DD Jump
            anim.SetBool("jump", true);
            Duckanim.SetBool("jump", true);

        }
        else
        {
            anim.SetBool("jump", false);
            Duckanim.SetBool("jump", false);
        }
        //Had to manually trigger the animation for forward & left("W & A")
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("forward", true);
            Duckanim.SetBool("forward", true);
        }
        else
        {
            anim.SetBool("forward", false);
            Duckanim.SetBool("forward", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("left", true);
            Duckanim.SetBool("left", true);
        }
        else
        {
            anim.SetBool("left", false);
            Duckanim.SetBool("left", false);
        }
        
        Vector3 direction = new Vector3(-horizontal, 0f, -vertical).normalized;
        //BKController.Move(direction * speed * Time.deltaTime);

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            /*if (controller.isGrounded)
            {
                // Jump
                if (Input.GetButtonDown("Jump"))
                {
                    moveDir.y = jumpForce; // Jump
                }
                else
                {
                    moveDir.y = -1; // Ensures contact with the ground
                }
            }
            else
            {
                // Apply Gravity
                moveDir.y = moveDir.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            }*/
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            //direction = moveDir;
        }
        /*else
        {
            direction = Vector3.zero;
        }
        BKController.Move(direction * speed * Time.deltaTime);*/
        #endregion

        #region Character Switching
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (currentChar)
            {
                case Characters.Eubie:
                    currentChar = Characters.DD;
                    EubieObject.SetActive(false);
                    DDObject.SetActive(true);
                    Debug.Log("Switching to DD!");
                    break;

                case Characters.DD:
                    currentChar = Characters.Eubie;
                    EubieObject.SetActive(true);
                    DDObject.SetActive(false);
                    Debug.Log("Switching to Eubie!");
                    break;
            }

        }
        #endregion

       #region Jump/Gravity Testing
        /*groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);*/


        // Changes the height position of the player..
        
        /*
        BKController.rb.AddForce(playerVelocity * Time.deltaTime);*/
        #endregion
    }

    private void OnGround()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 3.8f) && hit.transform.tag != "Water")
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        //return onGround;
    }

    public void OnDialogueEnd()
    {
        isInDialogue = false;
    }

    void Interact()
    {
        // Check input
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if NPC is active and not already talking
            if (NPC.ActiveNPC && !isInDialogue)
            {
                // Start dialog
                isInDialogue = true;
                DialogUI.Instance.dialogueRunner.StartDialogue(NPC.ActiveNPC.YarnStartNode);
            }
        }
    }
}
