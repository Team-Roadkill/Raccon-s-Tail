/////////////////////////////////////////////////////////
/// Creator : Chris Johnson - Made using chatgpt - not my work
/// Date Created : 17/05/2023
/// Purpose : move camera arround freely
/// Note : quickly made using chat gpt in order to film short clips for the trailer of the game
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDcameraMovementFilming : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        // Camera movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Camera rotation with the mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY, mouseX, 0f) * rotationSpeed * Time.deltaTime;
        transform.eulerAngles += rotation;
    }
}
