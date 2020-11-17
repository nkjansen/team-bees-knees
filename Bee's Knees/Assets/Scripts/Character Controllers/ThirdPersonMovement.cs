using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    #region Object Reference Variables
    public CharacterController controller;
    public Transform cam;
    public GameObject EubieObject;
    public GameObject DDObject;
    #endregion

    #region Movement Variables
    public float speed = 1f;
    public float jumpForce = 1f;
    public float gravityScale = 1f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
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

    private void Awake()
    {
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
        OnGround();
        //Debug.Log(onGround);
        Movement();
        characterSwitch();
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
    }

    private void Movement()
    {
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

        Vector3 direction = new Vector3(-horizontal, 0f, -vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    private void characterSwitch()
    {
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
    }

}
