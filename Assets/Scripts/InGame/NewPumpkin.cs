using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPumpkin : MonoBehaviour
{
    GameObject goPlayer;
    bool lockedOn = false;

    private void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (lockedOn == true)
        {
            transform.position = goPlayer.transform.position + new Vector3(0,10,0);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                lockedOn = true;
            }
        }

        if (other.gameObject.tag == "Dest")
        {
            lockedOn = false;
            transform.position = other.gameObject.transform.position;
        }

    }
}
