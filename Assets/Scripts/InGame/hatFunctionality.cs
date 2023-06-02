using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatFunctionality : MonoBehaviour
{
    [SerializeField] GameObject goBigHatModel;


    bool showHat;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            showHat = !showHat;
        }
        goBigHatModel.SetActive(showHat);
    }
}
