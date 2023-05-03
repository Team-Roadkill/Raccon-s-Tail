/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 03/05/2023
/// Purpose :
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTracking : MonoBehaviour
{
    float detectionAmount = 0f;


    private void OnTriggerStay(Collider other)
    {
        detectionAmount += Time.deltaTime;
    }
}
