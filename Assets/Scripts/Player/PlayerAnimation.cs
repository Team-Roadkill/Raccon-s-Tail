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
                    playerAnim.SetTrigger("Run");
                    playerAnim.ResetTrigger("Walk");
                }
                else //running not pressed
                {
                    playerAnim.ResetTrigger("Run");
                    playerAnim.SetTrigger("Walk");

                }
            }
            else if (Input.GetButton("Horizontal") == false &&
                    Input.GetButton("Vertical") == false
                    )
            {
                playerAnim.ResetTrigger("Walk");
                playerAnim.SetTrigger("Idle");
            }
        }
    }

    public void Jumping()
    {
        playerAnim.SetTrigger("Jumping");
        playerAnim.SetBool("Airborne", true);
    }

    public void Landing()
    {
        playerAnim.SetTrigger("Landing");
        playerAnim.SetBool("Airborne", false);
    }

}
