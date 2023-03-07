/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 06/02/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPortal : MonoBehaviour
{

    [SerializeField] GameObject goObjectLaunchFrom; //object that projectiles spawn from
    [SerializeField] GameObject[] goProjectilePrefabs; //list of objects that can be launched
    [SerializeField] Quaternion qLaunchDirection; //direction to launch objects in

    [SerializeField] float fForceAmount = 5f; //amount of force applied to obejects created
    [SerializeField] float fDelayBetweenLaunches = 0.5f; //time between objects being created
    [SerializeField] float fAngleDeviation = 10.0f; //angle variation of created objects
    [SerializeField] float fDestroyAfterxSeconds = 10.0f; //time before object should be destroyed

    bool bActive = false; //if the portals should be acitive
    bool bCanLaunch = true; //if the portals should be acitive
    

    // Update is called once per frame
    void Update()
    {
        
        if (bActive == true) //is the trap active
        {
            if (bCanLaunch == true) //can a new object be launched
            {
                StartCoroutine(Launch(fDelayBetweenLaunches)); //launch object
            }
        }
    }

    public IEnumerator Activate(float a_fTriggerDelay, float a_fActiveDuration) //int a_iNumberOfObjectsToSpawn
    {
        yield return new WaitForSeconds(a_fTriggerDelay); //delay before trap activates
        bActive = true; //run the trap

        yield return new WaitForSeconds(a_fActiveDuration); //duration trap is acitve
        bActive = false; //stop the trap
    }


    private IEnumerator Launch(float a_fLaunchDelay) //int a_iNumberOfObjectsToSpawn
    {
        bCanLaunch = false; //stop other objects spawning

        Vector3 v3Axis = Random.insideUnitSphere; //get a random point within sphere and store as a vector
        float fAngle = Random.Range(-fAngleDeviation, fAngleDeviation); //get a random float within deviation range
        Quaternion deviation = Quaternion.AngleAxis(fAngle, v3Axis); //create new rotation around the axis using the angle

        Quaternion qNewDirection = deviation * qLaunchDirection; //get new direction with deviation

        GameObject goPortalObject = Instantiate(goProjectilePrefabs[Random.Range(0, goProjectilePrefabs.Length - 1)],
            goObjectLaunchFrom.transform.position, qNewDirection); //create new projectile
        Rigidbody rb = goPortalObject.GetComponent<Rigidbody>(); //get the projectiles rigidbody
        rb.AddForce(qNewDirection * Vector3.forward * fForceAmount, ForceMode.Impulse); //apply a forice in the desired direction

        Destroy(goPortalObject, 5); //destroy the projectile after x seconds
        
        yield return new WaitForSeconds(a_fLaunchDelay); //delay before can launch new
        bCanLaunch = true; //a new object can be launched
    }

}
