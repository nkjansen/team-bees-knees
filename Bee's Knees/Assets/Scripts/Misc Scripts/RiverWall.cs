using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverWall : MonoBehaviour
{
    //drop player transform in this slot
    [SerializeField]
    private Transform player;
    //drop respawn point gameobject in this slot
    [SerializeField]
    private BoxCollider boxCollider;
    private bool IgnoredCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("Eubie"))
        {
            Physics.IgnoreLayerCollision(10, 11);
        }
    }
        
}
