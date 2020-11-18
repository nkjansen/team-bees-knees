using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //drop player transform in this slot
    [SerializeField] 
    private Transform player;
    //[SerializeField]
    //private Transform GameObject;
    //drop respawn point gameobject in this slot
    [SerializeField] 
    private Transform respawnPoint;

    private void OnTriggerEnter()
    {
        if (GameObject.FindWithTag("Eubie"))
        {
            //whenever the player jumps on the water, they will respawn to the respawnPoint
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }

        /*if (other.gameObject.tag =="DD")
        {
            GameObject.transform.position = GameObject.transform.position;
        }*/

    }

}
