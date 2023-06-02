using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyFound : MonoBehaviour
{
    [SerializeField] ExitLevel UIExitLevelRef;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIExitLevelRef.SuccessfulClear();
        }
    }
}
