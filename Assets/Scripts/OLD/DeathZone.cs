/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 02/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    ExitLevel exitLevelRef; //exit level ref

    /// <summary>
    /// if collision with player death screen
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        exitLevelRef = GameObject.FindGameObjectWithTag("UIobj").GetComponent<ExitLevel>(); //get dpm
        exitLevelRef.Death(); //run death function
    }
}
