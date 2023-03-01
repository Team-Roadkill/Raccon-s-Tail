/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 31/01/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller; //player controller
    public Transform tCamera; //camera transform

    public float fSpeed = 5f; //speed of camera
    public float fTurnSmoothTime = 0.1f; //smoothing of camera movement

    float fTurnSmoothVelocity; //private value for smoothing velocity

    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>(); //get the player controller
        tCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>(); //get the main camera
    }

    // Update is called once per frame
    void Update()
    {
        float fHorizontal = Input.GetAxisRaw("Horizontal"); //horizontal input
        float fVertical = Input.GetAxisRaw("Vertical"); //vertical input
        Vector3 v3Direction = new Vector3(fHorizontal, 0, fVertical).normalized; //get mouse dir

        if (v3Direction.magnitude >= 0.1f) //if the angle is greater than 
        {
            float fTargetAngle = Mathf.Atan2(v3Direction.x, v3Direction.z) * Mathf.Rad2Deg + tCamera.eulerAngles.y; //calculate the angle to target
            float fAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, fTargetAngle, ref fTurnSmoothVelocity, fTurnSmoothTime); //get a smooth to the movement
            transform.rotation = Quaternion.Euler(0f, fAngle, 0f); //rotate the player towards the angle

            Vector3 v3MoveDirection = Quaternion.Euler(0f, fTargetAngle, 0f) * Vector3.forward; //get the direction to move
            controller.Move(v3MoveDirection.normalized * fSpeed * Time.deltaTime); //move the player towards the desired dir
        }
    }
}
