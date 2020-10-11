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

    private void controlCheck()
    {
        if (Input.GetKey(Forward))
        {
            Debug.Log("Moving Forward!");
        }

        if (Input.GetKey(Backwards))
        {
            Debug.Log("Moving Backwards!");
        }

        if (Input.GetKey(Left))
        {
            Debug.Log("Moving Left!");
        }

        if (Input.GetKey(Right))
        {
            Debug.Log("Moving Right!");
        }

        if (Input.GetKeyDown(Jump))
        {
            Debug.Log("Jumping!");
        }
    }
}
