using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelSafe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ExitLevel exitLevel = FindObjectOfType<ExitLevel>();
        exitLevel.SuccessfulClear();
    }
}
