/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 07/03/2023
/// Purpose : disable traps
/////////////////////////////////////////////////////////
using UnityEngine;

public class Wand : MonoBehaviour
{
    private bool toolEnabled = false; //store if tool is equipped

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//if mouse click
        {
            if (toolEnabled == true) //check if tool equipped
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //cast a ray to mouse pos
                RaycastHit hit; //store hit info
                if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Trap")) //check trap hit
                {
                    GameObject trap; //store hit trap
                    trap = hit.collider.gameObject; //get trap
                    if (trap.GetComponent<Trap>() != null) //check if trap script exists
                    {
                        trap.GetComponent<Trap>().Disarm(); //disarm the trap
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //check 2 pressed 
        {

            if (toolEnabled == true) //if tool equipped
            {
                toolEnabled = false; //unequip tool
                Cursor.lockState = CursorLockMode.Locked; //lock cursor
                Cursor.visible = false; //hide cursor
            }
            else
            {
                toolEnabled = true; //equip tool
                Cursor.lockState = CursorLockMode.None; //disable cursor
                Cursor.visible = true; //show cursor

            }

        }
    }
}

