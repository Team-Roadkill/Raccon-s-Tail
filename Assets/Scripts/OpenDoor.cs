using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool opened = false;

    private void OnTriggerStay(Collider other)
    {
        // Check if the other object has a tag "Player"
        if (other.tag =="Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (opened == false)
                {
                    transform.Rotate(0, 90, 0);
                    opened = true;
                }
                
            }
            
        }
    }


}
