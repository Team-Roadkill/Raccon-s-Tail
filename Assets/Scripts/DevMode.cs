/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 01/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMode : MonoBehaviour
{
    [SerializeField] GameObject DevMenu; //dev menu ref

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.M)) //if both left ctrl and m pressed
        {
            DevMenu.SetActive(true); //show dev menu
            Cursor.lockState = CursorLockMode.None; // unlock cursor so shown
        }
        else if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.M)) //if both esc and m pressed
        {
            DevMenu.SetActive(false); //hide dev menu
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
