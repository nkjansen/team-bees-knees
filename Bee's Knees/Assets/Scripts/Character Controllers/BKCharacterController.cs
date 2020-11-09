using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKCharacterController : MonoBehaviour
{
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;

    public float horizontal;
    public float vertical;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = 0f;
        vertical = 0f;

        checkKeys();
    }

    private void checkKeys()
    {
        if (Input.GetKey(forward))
        {
            vertical = 1.0f;
        }
        if (Input.GetKey(backward))
        {
            vertical = -1.0f;
        }
        if (Input.GetKey(left))
        {
            horizontal = -1.0f;
        }
        if (Input.GetKey(right))
        {
            horizontal = 1.0f;
        }
        if (Input.GetKey(jump))
        {

        }

    }

    public void Move(Vector3 direction)
    {
        //rb.AddForce(direction, ForceMode.Impulse);
        //rb.MovePosition(transform.position + direction);
        rb.velocity = direction;
    }
}
