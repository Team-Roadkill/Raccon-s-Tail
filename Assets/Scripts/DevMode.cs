using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMode : MonoBehaviour
{
    [SerializeField] GameObject DevMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.M))
        {
            DevMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.M))
        {
            DevMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
