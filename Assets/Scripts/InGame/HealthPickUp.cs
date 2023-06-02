using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] heartsManager heartsManagerRef;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            heartsManagerRef.RegenOneHeart();
            gameObject.SetActive(false);
        }
    }


}
