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
    public Transform pointA; // Start point for rotation
    public Transform pointB; // End point for rotation
    public float rotationSpeed; // Speed of rotation
    public float visionConeAngle; // Angle of vision cone
    public float visionDistance; // Maximum distance for detecting objects
    public string playerTag; // Tag of the player object
    public float detectionTime; // Time it takes for detection to complete
    public GameObject detectionBar; // Bar object for detection progress

    private Quaternion initialRotation; // Initial rotation of the object
    private bool detectingPlayer; // Whether the player is currently being detected
    private float detectionProgress; // Current progress of detection
    private Vector3 detectionBarScale; // Initial scale of detection bar

    [SerializeField] Light spotLight;
    ExitLevel exitLevelRef;

    void Start()
    {
        exitLevelRef = FindAnyObjectByType<ExitLevel>();

        initialRotation = transform.rotation;
        detectingPlayer = false;
        detectionProgress = 0f;
        detectionBarScale = detectionBar.transform.localScale;

        spotLight.intensity = 20;
        spotLight.range = visionDistance;
        spotLight.spotAngle = visionConeAngle;


    }

    void Update()
    {
        //// Calculate the target rotation based on the current time
        //float t = Mathf.PingPong(Time.time * rotationSpeed, 1f);
        //Quaternion targetRotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, t);

        //// Apply the target rotation, but clamp it within the limits of pointA and pointB
        //float clampedYRotation = Mathf.Clamp(targetRotation.eulerAngles.y, pointA.rotation.eulerAngles.y, pointB.rotation.eulerAngles.y);
        //transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, clampedYRotation, initialRotation.eulerAngles.z);



        //float t = (Mathf.Sin(Time.time * rotationSpeed) + 1f) / 2f;
        //Quaternion targetRotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, t);
        //transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetRotation.eulerAngles.y, initialRotation.eulerAngles.z);



        // Check if the player is within the vision cone
        Collider[] colliders = Physics.OverlapSphere(transform.position, visionDistance);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag(playerTag))
            {
                Vector3 direction = collider.transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle < visionConeAngle / 2f)
                {
                    // The player is within the vision cone
                    if (!detectingPlayer)
                    {
                        // Start detecting the player
                        detectingPlayer = true;
                    }
                    else
                    {
                        // Update the detection progress
                        detectionProgress += Time.deltaTime / detectionTime;
                        detectionProgress = Mathf.Clamp(detectionProgress, 0f, 1f);
                        detectionBar.transform.localScale = new Vector3(detectionBarScale.x * detectionProgress, detectionBarScale.y, detectionBarScale.z);
                        if (detectionProgress >= 0.999f)
                        {
                            //spotted
                            exitLevelRef.Death();
                        }

                        transform.LookAt(GameObject.FindGameObjectWithTag("Player").gameObject.transform);
                    }
                    return;

                }
            }
        }


        float t = (Mathf.Sin(Time.time * rotationSpeed) + 1f) / 2f;
        Quaternion targetRotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, t);
        transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetRotation.eulerAngles.y, initialRotation.eulerAngles.z);


        // The player is not within the vision cone
        detectingPlayer = false;
        detectionProgress = 0f;
        detectionBar.transform.localScale = new Vector3(0f, detectionBarScale.y, detectionBarScale.z);
    }
}