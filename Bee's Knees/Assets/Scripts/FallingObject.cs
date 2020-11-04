using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private bool isFalling = false;
    private float downSpeed = 0;
    //private Vector3 checkpoint;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == ("player"))
            isFalling = true;
            //Object disappears after 4 seconds
            Destroy(gameObject, 4);
        //the current position of the object
        //where the object resets to
        //checkpoint = new Vector3(1.1f, -9.4f);
    }

    void Update()
    {
        if (isFalling)
        {
            //Acceleration of the object falling
            //The higher the number the slower the object falls
            downSpeed += Time.deltaTime/9770;
            //changing the position of the object falling(down)
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
        }

        //whenever the object gets below 2 on the y axis
        //if (transform.position.y < -15.9)
        {
            //object resets to the original postion
            //transform.position = checkpoint;
        }
    }
}
