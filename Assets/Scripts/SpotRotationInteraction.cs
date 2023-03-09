using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotRotationInteraction : MonoBehaviour
{
    [SerializeField] float fDuration = 1f; //duration the door will take from point 1 to 2
    [SerializeField] bool bOpen = false; //if the door has been opened
    [SerializeField] Vector3 v3RotationAmount = new Vector3(0,90,0); //amount the object will rotate and what axis

    Quaternion startRotation; //starting rotation of the object
    Quaternion endRotation; //goal rotation of the object
    float fTime = 0f; //time past
   
    void Start()
    {
        startRotation = gameObject.transform.rotation; //get starting rotation
        endRotation = Quaternion.Euler(v3RotationAmount); //set end rotation
    }

    void Update()
    {
        if (bOpen == true)
        {
            fTime += Time.deltaTime; //increase time
            Quaternion qRotation = Quaternion.Lerp(startRotation, endRotation, Mathf.Clamp01(fTime / fDuration)); //get rotation
            gameObject.transform.rotation = qRotation; //rotate object
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if the player is near and interacts set the door to open
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (bOpen == false)
                {
                    bOpen = true;
                }
            }

        }
    }
}
