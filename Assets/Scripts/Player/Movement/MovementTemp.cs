using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTemp : MonoBehaviour
{
    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-transform.right);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(transform.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back);
        if (Input.GetKey(KeyCode.Q))
            gameObject.transform.Rotate(new Vector3(0, -1, 0));
        if (Input.GetKey(KeyCode.E))
            gameObject.transform.Rotate(new Vector3(0, 1, 0));
    }
}
