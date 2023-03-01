/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 06/02/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{
    [SerializeField]
    GameObject goSpikes;

    // Start is called before the first frame update
    void Start()
    {
        UpdateVisibility(goSpikes, false);
    }

    /// <summary>
    /// hide attached object and collider
    /// </summary>
    public void UpdateVisibility(GameObject a_goObjectToChange, bool a_bVisibility)
    {
        a_goObjectToChange.GetComponent<Renderer>().enabled = a_bVisibility;
        a_goObjectToChange.GetComponent<Collider>().enabled = a_bVisibility;

        if (a_bVisibility == true)
        {
            //play spike trap audio



        }

    }

    /// <summary>
    /// activate trap
    /// </summary>
    /// <param time to wait for trap to trigger="a_fTriggerDelay"></param>
    /// <param time the trap remains active="a_fActiveDuration"></param>
    /// <returns></returns>
    public IEnumerator Activate(float a_fTriggerDelay, float a_fActiveDuration)
    {
        yield return new WaitForSeconds(a_fTriggerDelay);
        UpdateVisibility(goSpikes, true);
        yield return new WaitForSeconds(a_fActiveDuration);
        UpdateVisibility(goSpikes, false);
    }
}
