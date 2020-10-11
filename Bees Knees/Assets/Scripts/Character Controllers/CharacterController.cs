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

    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 1f;


    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        controlCheck();
    }
    #endregion

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

    #region Movement Methods
    private void moveForward()
    {
        Debug.Log("Moving Forward!");
    }

    private void moveBack()
    {
        Debug.Log("Moving Backwards!");
    }

    private void moveLeft()
    {
        Debug.Log("Moving Left!");
    }

    private void moveRight()
    {
        Debug.Log("Moving Right!");
    }

    private void jump()
    {
        Debug.Log("Jumping!");
    }
    #endregion
}
