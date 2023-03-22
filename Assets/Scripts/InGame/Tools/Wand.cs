/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 07/03/2023
/// Purpose : disable traps
/////////////////////////////////////////////////////////
using UnityEngine;

public class Wand : MonoBehaviour
{
    private bool bToolActive = false; //store if tool is equipped

    [SerializeField] float fTrapRevealDuration = 1f;
    [SerializeField] float fTrapRevealDistance = 15f;
    [SerializeField] GameObject fTrapRevealedParticles;

    [SerializeField] float fTimeBetweenUses = 2f;
    float fTimeBetweenUsesCooldown = 0f;

    private void Update()
    {

        //if (Input.GetMouseButtonDown(0))//if mouse click
        //{
        //    if (bToolActive == true) //check if tool equipped
        //    {
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //cast a ray to mouse pos
        //        RaycastHit hit; //store hit info
        //        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Trap")) //check trap hit
        //        {
        //            GameObject trap; //store hit trap
        //            trap = hit.collider.gameObject; //get trap
        //            if (trap.GetComponent<Trap>() != null) //check if trap script exists
        //            {
        //                trap.GetComponent<Trap>().Disarm(); //disarm the trap
        //            }
        //        }
        //    }
        //}

        fTimeBetweenUsesCooldown -= Time.deltaTime;
        if (fTimeBetweenUsesCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2)) //check 2 pressed 
            {
                fTimeBetweenUsesCooldown = fTimeBetweenUses;
                Collider[] colliders = Physics.OverlapSphere(transform.position, fTrapRevealDistance); //get all objects within range
                foreach (Collider c in colliders)
                {
                    if (c.gameObject.tag == "Trap")
                    {
                        GameObject goTrapLight = Instantiate(fTrapRevealedParticles, c.gameObject.transform.position, transform.rotation);
                        Destroy(goTrapLight, fTrapRevealDuration);
                    }
                }

                //if (bToolActive == true) //if tool equipped
                //{
                //    bToolActive = false; //unequip tool
                //    Cursor.lockState = CursorLockMode.Locked; //lock cursor
                //    Cursor.visible = false; //hide cursor
                //}
                //else
                //{
                //    bToolActive = true; //equip tool
                //    Cursor.lockState = CursorLockMode.None; //disable cursor
                //    Cursor.visible = true; //show cursor
                //}
            }
        }
    }
}

