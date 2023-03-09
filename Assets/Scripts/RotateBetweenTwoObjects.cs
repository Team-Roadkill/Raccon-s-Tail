using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBetweenTwoObjects : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public float rotationSpeed = 5f;
    public float waitTime = 1f;

    void Start()
    {
        StartCoroutine(RotateTargets());
    }

    IEnumerator RotateTargets()
    {
        while (true)
        {
            // Rotate towards target A
            Quaternion targetRotationA = Quaternion.LookRotation(targetA.position - transform.position);
            while (Quaternion.Angle(transform.rotation, targetRotationA) > 0.1f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationA, Time.deltaTime * rotationSpeed);
                yield return null;
            }

            // Wait for a brief moment
            yield return new WaitForSeconds(waitTime);

            // Rotate towards target B
            Quaternion targetRotationB = Quaternion.LookRotation(targetB.position - transform.position);
            while (Quaternion.Angle(transform.rotation, targetRotationB) > 0.1f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationB, Time.deltaTime * rotationSpeed);
                yield return null;
            }

            // Wait for a brief moment
            yield return new WaitForSeconds(waitTime);
        }
    }
}
