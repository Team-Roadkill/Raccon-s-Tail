/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 06/02/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPortals : MonoBehaviour
{

    [SerializeField] GameObject goPositionOne;
    [SerializeField] GameObject goPositionTwo;

    [SerializeField] GameObject[] goProjectilePrefabs;

    GameObject goPortalObject;

    

    enum dir
    {
        x,
        y,
        z
    }
    [SerializeField]
    dir dDirection;

    bool bActive = false; //if the portals should be acitive
    bool bFirstPass = true; //store if its the first update after portals should close


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bActive == true)
        {
            if (goPortalObject != null)
            {
                goPortalObject = Instantiate(goProjectilePrefabs[Random.Range(0, goProjectilePrefabs.Length - 1)],
            goPositionOne.transform.position, new Quaternion(0, 0, 0, 0)); //create new object
            }
        }
        else
        {

        }

        //if active
        //if no objects active
        //create objects
        //else
        
        //script attached to object :
        //pos 1
        //pos 2
        //go to target
        //if at target
        //tp to pos 1



    }

    public IEnumerator Activate(float a_fTriggerDelay, float a_fActiveDuration, int a_iNumberOfObjectsToSpawn)
    {
        yield return new WaitForSeconds(a_fTriggerDelay);
        bActive = true;

        yield return new WaitForSeconds(a_fActiveDuration);
        bActive = false;
    }

}
