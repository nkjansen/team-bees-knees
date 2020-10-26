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
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    #endregion

    #region Character Switching Values
    private enum Characters
    {
        Eubie,
        DD
    }
    private Characters currentChar;
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
        /*
         * TODO:
         * Create a custom character controller (again) that allows the use of rigid bodies
         * The float values used here are just -1, 0, and 1, which I can easily simulate
         * with the boolean Input.GetKeyDown. This will allow me to keep the camera
         * turning functionality, while using my own character controller, and have
         * customizable buttons
         */
        #region Character Turning and Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontal);
        float vertical = Input.GetAxisRaw("Vertical");
        //Debug.Log(vertical);
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
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
    }
}
