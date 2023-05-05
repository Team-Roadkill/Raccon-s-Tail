/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 02/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] Quaternion qRotationOne; // first rotation angle
    [SerializeField] Quaternion qRotationTwo; // second rotation angle
    public float fRotationSpeed; // rotation speed
    private Quaternion qInitialRotation; // starting rotation

    [SerializeField] float fVisionConeAngle; // vision angle
    [SerializeField] float fVisionDistance; // vision distance
    [SerializeField] float fDetectionTime; // time needed before 100% detection

    [SerializeField] GameObject goDetectionBar; // bar to display detection progress
    float fDetectionProgress; // progress of detection
    Vector3 v3DetectionBarScale; // scale of detection bar

    [SerializeField] Light spotLight; //light to show detection cone
    ExitLevel exitLevelRef; //exit level ref

    void Start()
    {
        //get script referances
        exitLevelRef = FindAnyObjectByType<ExitLevel>();

        //setup rotation values
        qInitialRotation = transform.rotation;

        //set up detection values
        fDetectionProgress = 0f;
        v3DetectionBarScale = goDetectionBar.transform.localScale;

        //set up light values
        spotLight.intensity = 1000;
        spotLight.range = fVisionDistance + 15;
        spotLight.spotAngle = fVisionConeAngle;
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, fVisionDistance); //get all objects within range
        foreach (Collider collider in colliders) //check each object in range
        {
            if (collider.gameObject.tag == "Player") //if the object is the player
            {
                Vector3 direction = collider.transform.position - transform.position; //get direction to object
                float angle = Vector3.Angle(direction, transform.forward); //get the angle distance from looking dir to player
                if (angle < fVisionConeAngle / 2f) //is the player within the vision angle
                {
                    fDetectionProgress += Time.deltaTime / fDetectionTime; //increase detection
                    fDetectionProgress = Mathf.Clamp(fDetectionProgress, 0f, 1f); //clamp detection progress
                    goDetectionBar.transform.localScale = new Vector3(v3DetectionBarScale.x * fDetectionProgress, v3DetectionBarScale.y, v3DetectionBarScale.z); //scale pysical detection bar
                    if (fDetectionProgress >= 0.999f) // if player fully detected
                    {
                        exitLevelRef.Death(); //kill the player
                    }

                    transform.LookAt(GameObject.FindGameObjectWithTag("Player").gameObject.transform); //lock on to player

                    //add check to get if angle exits point a and b angles
                    //clamp value inside values

                    return; //stop checking collider list
                }
            }
        }

        //rotate the player between the two points

        qRotationOne.Normalize();
        qRotationTwo.Normalize();

        float t = (Mathf.Sin(Time.time * fRotationSpeed) + 1f) / 2f;
        Quaternion targetRotation = Quaternion.Lerp(qRotationOne, qRotationTwo, t);
        transform.rotation = Quaternion.Euler(qInitialRotation.eulerAngles.x, targetRotation.eulerAngles.y, qInitialRotation.eulerAngles.z);

        fDetectionProgress = 0f;
        goDetectionBar.transform.localScale = new Vector3(0f, v3DetectionBarScale.y, v3DetectionBarScale.z);
    }
}