/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 04/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCamera;
    Transform unit;
    [SerializeField] Transform worldSpaceCanvas;

    public Vector3 offset;


    private void OnEnable()
    {
        mainCamera = Camera.main.transform;
        unit = transform.parent;

        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position);
        transform.position = unit.position + offset;
    }
}
