/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 31/01/2023
/// Purpose : temp usage of locking cursor
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{

    [SerializeField] GameObject goSideBarRef;

    bool bLockCursor = false;

    private void Update()
    {
        if (goSideBarRef != null)
        {
            if (goSideBarRef.gameObject.activeSelf == true)
            {
                bLockCursor = false;
            }
            else
            {
                bLockCursor = true;
            }
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (bLockCursor == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (bLockCursor == true)
        {
            if (hasFocus)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Application is focussed");
            }
            else
            {
                Debug.Log("Application lost focus");
            }
        }
    }
}
