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




    bool bReachedDestination = false;
    bool bAttachedToPlayer = false;
    GameObject goPlayerRef;

    Quaternion qInteractRotation = new Quaternion(0.707106829f, 0, 0, 0.707106829f);



    private void Update()
    {
        if (bAttachedToPlayer == true)
        {
            //transform.Rotate(0, 1, 0);
            transform.position = goPlayerRef.gameObject.transform.position + new Vector3(0, 2, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (bReachedDestination == false)
                {
                    if (bAttachedToPlayer == false)
                    {
                        goPlayerRef = other.gameObject;
                        //transform.rotation = qInteractRotation;
                        bAttachedToPlayer = true;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                bAttachedToPlayer = false;
            }
        }

        if (other.transform.tag == "Dest")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            gameObject.transform.position = other.gameObject.transform.position;
            gameObject.transform.rotation = other.gameObject.transform.rotation;
            bReachedDestination = true;
            bAttachedToPlayer = false;
        }
    }

}
