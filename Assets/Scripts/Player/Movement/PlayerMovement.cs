using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    //obj ref
    [SerializeField] CharacterController cController; //char controller
    CinemachineVirtualCamera cmVirtualCamera; //camera
    PlayerAnimation PlayerAnimationRef;


    float fSpeed = 5f; // speed
    public float fWalkingSpeed = 5f; // walking speed
    public float fRunngingSpeed = 10f; // running speed
    public float fJumpHeight = 2f; // jump height
    Vector3 v3Velocity; // player velocity

    bool bIsGrounded; //store if the player is on the ground
    public float fGroundDistance = 1.3f; // distance to check to the ground

    //Vector3[] v3RaycastPositions = new Vector3[5]; //rays cast below player
    //[SerializeField] float fRaySpacing = 0.25f; //ray spacing


    void Start()
    {
        cmVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>(); //cinemachine camera
        PlayerAnimationRef = gameObject.GetComponent<PlayerAnimation>(); //get player animation script

        //v3RaycastPositions[0] = transform.position;
        //v3RaycastPositions[1] = transform.position + (Vector3.left * fRaySpacing);
        //v3RaycastPositions[2] = transform.position + (Vector3.right * fRaySpacing);
        //v3RaycastPositions[3] = transform.position + (Vector3.forward * fRaySpacing);
        //v3RaycastPositions[4] = transform.position + (Vector3.back * fRaySpacing);
    }

    void Update()
    {
        Vector3 v3CameraForward = cmVirtualCamera.transform.forward; //camera forward vector
        Vector3 v3CameraRight = cmVirtualCamera.transform.right; //camera right vector

        v3CameraForward.y = 0f; //remove height component 
        v3CameraRight.y = 0f; //remove height component 

        v3CameraForward.Normalize(); //normailize the camera forward
        v3CameraRight.Normalize(); //normailize the camera right

        float fHorizontalAxis = Input.GetAxisRaw("Horizontal"); //user input
        float fVerticalAxis = Input.GetAxisRaw("Vertical"); //user input

        Vector3 v3InputDirection = Vector3.zero; //store input direction
        v3InputDirection = fHorizontalAxis * v3CameraRight + fVerticalAxis * v3CameraForward; //calculate input direction

        if (Input.GetKey(KeyCode.LeftShift)) //if shift pressed running
        {
            fSpeed = fRunngingSpeed; //set speed to running speed
        }
        else
        {
            fSpeed = fWalkingSpeed; //set speed to walking speed
        }

        cController.Move(v3InputDirection * fSpeed * Time.deltaTime + v3Velocity * Time.deltaTime); //move the player
        
        
        transform.LookAt(transform.position + v3InputDirection); // rotate the player

        //foreach (Vector3 pos in v3RaycastPositions) //for each ray cast pos
        //{
        //    if (Physics.Raycast(pos, Vector3.down, fGroundDistance)) //cast ray
        //    {
        //        bIsGrounded = true; //ground is near 
        //    }
        //}
        bIsGrounded = Physics.Raycast(transform.position, Vector3.down, fGroundDistance); //cast a ray to check if touching ground layer
        
        if (Input.GetButtonDown("Jump")) //if jump pressed
        {
            if (bIsGrounded == true) //if on ground
            {
                v3Velocity.y = Mathf.Sqrt(fJumpHeight * -2f * Physics.gravity.y); //
                PlayerAnimationRef.Jumping();
            }
        }

        if (PlayerAnimationRef.playerAnim.GetBool("Airborne") == true)
        {
            //foreach (Vector3 pos in v3RaycastPositions) //for each ray cast pos
            //{
                if (Physics.Raycast(transform.position, Vector3.down, 2f))
                {
                    PlayerAnimationRef.Landing();
                }
            //}
        }


        v3Velocity.y += Physics.gravity.y * Time.deltaTime; //set player velocity

        if (bIsGrounded == true) //if ground in range
        {
            if (v3Velocity.y < 0) //if any downward velocity
            {
                v3Velocity.y = -4f; //set to acceptable downward velo
            }
        }


        if (bIsGrounded == true)
        {
            if (PlayerAnimationRef.playerAnim.GetBool("Airborne") == false)
            {
                PlayerAnimationRef.Landing();
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        //foreach (Vector3 pos in v3RaycastPositions)
        //{
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * fGroundDistance);
        //}
    }

}
