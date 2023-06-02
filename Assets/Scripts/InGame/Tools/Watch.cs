/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 17/02/2023
/// Purpose :  manage tools if unlocked, if equipped and interaction
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour
{
    [SerializeField] float fWatchDetectDistance = 5f; //distance watch can detect traps
    [SerializeField] float fLingerDuration = 1f; //duration effect is active
    [SerializeField] GameObject trapInArea; //effect for a nearby trap
    [SerializeField] float fTimeBetweenChecks = 1f; //time between updates

    //[SerializeField] GameObject goTimeDisplay;
    //[SerializeField] GameObject goDayCountDisplay;

    [SerializeField] GameObject goWatchGlow;

    float fTimeCount = 0f; //time to countdown

    private void Start()
    {
        //if (goTimeDisplay)
        //{
        //    goTimeDisplay.SetActive(true);
        //}
        //if (goDayCountDisplay)
        //{
        //    goDayCountDisplay.SetActive(true);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fTimeCount > 0)
        {
            fTimeCount -= Time.deltaTime;
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, fWatchDetectDistance); //get all objects within range
            foreach (Collider c in colliders)
            {
                if (c.gameObject.tag == "Trap")
                {
                    GameObject goWatchLight = Instantiate(goWatchGlow, gameObject.transform.position, transform.rotation, gameObject.transform);
                    Destroy(goWatchLight, fLingerDuration);

                }
            }
            fTimeCount = fTimeBetweenChecks;
        }
    }
}
