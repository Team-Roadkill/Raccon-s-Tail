/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 22/03/2023
/// Purpose : on collision with player teleport to new pos obj
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDisarmInteract : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //if player inside
        {
            
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") //if player inside
        {
            if (Input.GetKey(KeyCode.E)) //if player interacting
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 2); //get all objects within range
                foreach (Collider coll in colliders)
                {
                    if (coll.gameObject.tag == "Trap") //if trap near
                    {
                        coll.GetComponent<Trap>().Disarm(); //disarm the trap
                        //could play animation of trap destruction here
                        Destroy(this.gameObject); //destroy this effect
                    }
                }
            }
        }
    }

}
