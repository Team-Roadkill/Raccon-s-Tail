/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 02/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnim;

    void Update()
    {
        if (playerAnim.GetBool("Airborne") == false)
        {
            //if any dir is pressed
            if (Input.GetButton("Horizontal") |
                Input.GetButton("Vertical")
                )
            {
                if (Input.GetKey(KeyCode.LeftShift)) //running pressed
                {
                    playerAnim.SetTrigger("TriggerRun");
                    playerAnim.ResetTrigger("TriggerWalk");
                }
                else //running not pressed
                {
                    playerAnim.ResetTrigger("TriggerRun");
                    playerAnim.SetTrigger("TriggerWalk");

                }
            }
            else if (Input.GetButton("Horizontal") == false &&
                    Input.GetButton("Vertical") == false
                    )
            {
                playerAnim.ResetTrigger("TriggerWalk");
                playerAnim.SetTrigger("TriggerIdle");
            }
        }
    }


    public void Interact()
    {
        playerAnim.SetTrigger("Interact");
    }



    public void Jumping()
    {
        playerAnim.SetTrigger("TriggerJumpStart");
        playerAnim.SetBool("Airborne", true);
    }

    public void Landing()
    {
        playerAnim.SetTrigger("TriggerJumpLand");
        playerAnim.SetBool("Airborne", false);
    }

}
