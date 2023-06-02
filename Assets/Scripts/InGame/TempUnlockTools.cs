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
    //ToolManager tmRef;
    [SerializeField] GameObject goWatch;
    [SerializeField] GameObject goHat;
    [SerializeField] GameObject goWand;


    [Header("Tool - 1-4")]
    [SerializeField] int tool;

    private void Start()
    {
        //tmRef = FindAnyObjectByType<ToolManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (tool == 1)
            {
                //tmRef.UnlockWatch();
                goWatch.SetActive(true);

            }
            else if (tool == 2)
            {
                //tmRef.UnlockWand();
                goWand.SetActive(true);
            }
            else if (tool == 3)
            {
                //tmRef.UnlockGauntlet();
            }
            else if (tool == 4)
            {
                //tmRef.UnlockHat();
                goHat.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        
        
    }

}
