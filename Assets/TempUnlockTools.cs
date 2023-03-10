/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 10/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUnlockTools : MonoBehaviour
{
    ToolManager tmRef;

    [Header("Tool - 1-4")]
    [SerializeField] int tool;

    private void Start()
    {
        tmRef = FindAnyObjectByType<ToolManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tool == 1)
        {
            tmRef.UnlockWatch();
        }
        else if (tool == 2)
        {
            tmRef.UnlockWand();
        }
        else if (tool == 3)
        {
            tmRef.UnlockGauntlet();
        }
        else if (tool == 4)
        {
            tmRef.UnlockHat();
        }
        Debug.Log(tool.ToString() + ": unlocked");
        gameObject.SetActive(false);
    }

}
