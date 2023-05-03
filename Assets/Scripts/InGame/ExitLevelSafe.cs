/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 03/05/2023
/// Purpose :
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelSafe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ExitLevel exitLevel = FindObjectOfType<ExitLevel>();
            exitLevel.SuccessfulClear();
        }
        
    }
}
