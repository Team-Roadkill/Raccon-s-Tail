/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 22/03/2023
/// Purpose : on collision with player teleport to new pos obj
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] GameObject goNewPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = goNewPos.transform.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

}
