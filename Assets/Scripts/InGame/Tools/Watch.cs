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

    [SerializeField] GameObject goTimeDisplay;
    [SerializeField] GameObject goDayCountDisplay;

    float fTimeCount = 0f; //time to countdown

    private void Start()
    {
        goTimeDisplay.SetActive(false);
        goDayCountDisplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            goTimeDisplay.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            goTimeDisplay.SetActive(false);
        }


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
                    GameObject goTrapLight = Instantiate(trapInArea, c.gameObject.transform.position, transform.rotation);
                    Destroy(goTrapLight, fLingerDuration);
                }
            }
            fTimeCount = fTimeBetweenChecks;
        }
    }
}
