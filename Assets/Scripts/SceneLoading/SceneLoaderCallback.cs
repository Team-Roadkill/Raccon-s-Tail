/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 28/01/2023
/// Purpose : Script for an inbetween callback attached scene to be loaded and displayed before the next
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderCallback : MonoBehaviour
{
    bool bFirstUpdate = true;


    // Update is called once per frame
    void Update()
    {
        if (bFirstUpdate == true)
        {
            bFirstUpdate = false;
            SceneLoader.loaderCallback();
        }
    }
}
