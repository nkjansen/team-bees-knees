using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //drop player transform in this slot
    [SerializeField] 
    private Transform player; 
    //drop respawn point gameobject in this slot
    [SerializeField] 
    private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //whenever the player jumps on the water, they will respawn to the respawnPoint
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }
}
