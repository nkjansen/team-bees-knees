using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Controls
    [SerializeField]
    private KeyCode Forward = KeyCode.W;
    [SerializeField]
    private KeyCode Backwards = KeyCode.S;
    [SerializeField]
    private KeyCode Left = KeyCode.A;
    [SerializeField]
    private KeyCode Right = KeyCode.D;
    [SerializeField]
    private KeyCode Jump = KeyCode.Space;
    #endregion

    #region Camera Rotation Variables
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;
    #endregion

    #region Movement Variables
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 5f;
    private bool isGrounded;
    [SerializeField]
    private float jumpHeight = 1f;
    private Vector3 vJumpHeight;
    #endregion
    
    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        vJumpHeight = new Vector3(0, jumpHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        controlCheck();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
    #endregion

    #region Movement Methods
    private void controlCheck()
    {
        if (Input.GetKey(Forward))
        {
            moveForward();
        }

        if (Input.GetKey(Backwards))
        {
            moveBack();
        }

        if (Input.GetKey(Left))
        {
            moveLeft();
        }

        if (Input.GetKey(Right))
        {
            moveRight();
        }

        if (Input.GetKeyDown(Jump))
        {
            jump();
        }
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }

    private void moveForward()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        Debug.Log("Moving Forward!");
    }

    private void moveBack()
    {
        transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        Debug.Log("Moving Backwards!");
    }

    private void moveLeft()
    {
        transform.position -= transform.right * Time.deltaTime * moveSpeed;
        Debug.Log("Moving Left!");
    }

    private void moveRight()
    {
        transform.position += transform.right * Time.deltaTime * moveSpeed;
        Debug.Log("Moving Right!");
    }

    private void jump()
    {
        if (isGrounded)
        {
            rb.AddForce(vJumpHeight * moveSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
        //rb.transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed), Space.World);
        Debug.Log("Jumping!");
    }
    #endregion
}