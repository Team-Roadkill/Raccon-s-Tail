/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 07/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using UnityEngine;

public class Wand : MonoBehaviour
{
    // Reference to the trap object
    private GameObject trap;

    // Toggle to enable and disable the tool
    private bool toolEnabled = false;

    private void Update()
    {
        // Check if the tool is enabled
        if (toolEnabled == true)
        {
            // Check if the left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("ray casted");
                // Cast a ray from the mouse position to detect objects
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Check if the ray hits an object with the "Trap" tag
                if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Trap"))
                {
                    // Get the trap object and call Disarm on its Trap script
                    trap = hit.collider.gameObject;
                    if (trap.GetComponent<Trap>() != null)
                    {
                        trap.GetComponent<Trap>().Disarm();
                    }
                }
            }
        }

        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha2)) //num 2 top
        {

            if (toolEnabled == true)
            {
                toolEnabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                toolEnabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }

        }
    }
}

