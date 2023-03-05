/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 04/03/2023
/// Purpose : script to lock pumpkin in place if it collides with the destination trigger
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinDest : MonoBehaviour
{
    [SerializeField] Transform lockPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Dest")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            gameObject.transform.position = other.gameObject.transform.position;
            gameObject.transform.rotation = other.gameObject.transform.rotation;
        }
    }
}
