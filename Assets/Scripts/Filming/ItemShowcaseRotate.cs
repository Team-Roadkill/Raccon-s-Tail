/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 17/05/2023
/// Purpose :  rotate object
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShowcaseRotate : MonoBehaviour
{
    [SerializeField] float fSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * fSpeed * Time.deltaTime);

    }
}
